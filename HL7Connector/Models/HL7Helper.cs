using HL7.Dotnetcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7CreationFromJson
{
    class Hl7Helper
    {
        
        public static string GetHL7Format(JsonHL7Fields inpModel)
        {            

            Message oHl7Message = new Message();

            // Add MSH Segment
            Segment mshSegment = new Segment("MSH", new HL7Encoding());
            mshSegment.AddNewField(inpModel.SendingApplication ?? "", 3);
            mshSegment.AddNewField(inpModel.SendingFacility ?? "", 4);
            mshSegment.AddNewField(inpModel.ReceivingApplication ?? "", 5);
            mshSegment.AddNewField(inpModel.ReceivingFacility ?? "", 6);
            mshSegment.AddNewField(DateTime.Now.ToString("yyyymmddhhMMss"), 7);
            mshSegment.AddNewField("ORM^001", 9); // Message type
            mshSegment.AddNewField(inpModel.AppointmentId ?? "", 10);
            mshSegment.AddNewField("D", 11); // D=Debugging; P=Production; T=Training 
            mshSegment.AddNewField("2.3", 12); // Message version
            mshSegment.AddNewField("AL", 15); 
            mshSegment.AddNewField("NE", 16);
            mshSegment.AddNewField("IHE_PCD_ORU_R01^IHE_PCD^1.3.6.1.4.1.19376.1.6.1.1.1^ISO", 21);
            oHl7Message.AddNewSegment(mshSegment);

            // Add PID Segment
            Segment pidSegment = new Segment("PID", new HL7Encoding());
            pidSegment.AddNewField("1", 1);
            pidSegment.AddNewField(inpModel.PatientIdentifier ?? "", 2); // Patient ID
          //  pidSegment.AddNewField(inpModel.PatientIdentifier ?? "", 4); // Alternate Patient ID
            pidSegment.AddNewField($"{inpModel.PatientLastName ?? ""}^{inpModel.PatientFirstName ?? ""}^{inpModel.PatientMiddleName ?? ""}^{inpModel.PatientSuffix ?? ""}^{inpModel.PatientPrefix ?? ""}", 5); // Patient Name
            pidSegment.AddNewField(inpModel.PatientDOB ?? "", 7); // Patient DOB
            pidSegment.AddNewField(inpModel.PatientGender ?? "", 8); // Patient Gender
         //   pidSegment.AddNewField(inpModel.PatientAddress ?? "", 11); // Patient Address
          //  pidSegment.AddNewField(inpModel.PatientPhoneHome ?? "", 13); // Patient Home Phone number
         //   pidSegment.AddNewField(inpModel.PatientSSN ?? "", 19); // Patient SSN Number
            oHl7Message.AddNewSegment(pidSegment);

            // Add PV1 Segment
            Segment pv1Segment = new Segment("PV1", new HL7Encoding());
            pidSegment.AddNewField(inpModel.PatientClass ?? "", 2);
            pidSegment.AddNewField(inpModel.AssignedLocation ?? "", 3);
            pv1Segment.AddNewField($"{inpModel.PhysicianNpi ?? ""}^{inpModel.PhysicianLastName ?? ""}^{inpModel.PhysicianFirstName??""}^{inpModel.PhysicianMiddleName ?? ""}^{inpModel.PhysicianSuffix ?? ""}^{inpModel.PhysicianPrefix ?? ""}", 8); // Physician information
            oHl7Message.AddNewSegment(pv1Segment);
           

            // Add ORC Segment
            Segment orcSegment = new Segment("ORC", new HL7Encoding());
            orcSegment.AddNewField("NW", 1); // New Order
            orcSegment.AddNewField(inpModel.OrderNumber, 2); //Order Number
            orcSegment.AddNewField(inpModel.ExpectedExamDateTime ?? "", 7); // Date/Time of Order fullfilled
            orcSegment.AddNewField(inpModel.CollectionDateTime ?? "", 9); // Date/Time of Transaction
            orcSegment.AddNewField($"{inpModel.OrderingProviderNpi ?? ""}^{inpModel.OrderingProviderLastName ?? ""}^{inpModel.OrderingProviderFirstName ?? ""}^{inpModel.OrderingProviderMiddleName ?? ""}^{inpModel.OrderingProviderSuffix ?? ""}^{inpModel.OrderingProviderPrefix ?? ""}", 12); // Ordering Provider
            orcSegment.AddNewField(inpModel.ProviderLocation, 13);
            orcSegment.AddNewField(inpModel.ProviderPhoneNumber, 14);
            oHl7Message.AddNewSegment(orcSegment);

            // Add OBR Segment
            Segment obrSegment = new Segment("OBR", new HL7Encoding());
            obrSegment.AddNewField(inpModel.SetId ?? "", 1);
            obrSegment.AddNewField(inpModel.PlacerOrderNumber ?? "", 2);
            obrSegment.AddNewField(inpModel.UniversalServiceID ?? "", 4);
            obrSegment.AddNewField(inpModel.CollectionDateTime ?? "", 6); // Date/Time of Transaction
            obrSegment.AddNewField(inpModel.ProcedureCode ?? "", 46);
            oHl7Message.AddNewSegment(obrSegment);

            // Add Diagnosis
            for (int i = 0; i < inpModel.Comments.Count; i++)
            {
                Segment NTESegment = new Segment("NTE", new HL7Encoding());
                NTESegment.AddNewField((i + 1).ToString(), 1);
                NTESegment.AddNewField(inpModel.Comments[i].SourceOfComment, 2);
                NTESegment.AddNewField(inpModel.Comments[i].Comment, 3); 
                oHl7Message.AddNewSegment(NTESegment);
            }


            string oRetMessage = oHl7Message.SerializeMessage(false);

            return oRetMessage;
        }
    }
}