using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7CreationFromJson
{
    public class JsonHL7Fields
    {
        
        public string SendingApplication { get; set; } // MSH-3
        public string SendingFacility { get; set; } //MSH-4 
        public string ReceivingApplication { get; set; } //MSH-5
        public string ReceivingFacility { get; set; } // MSH-6

        public string MessageCode { get; set; } // MSH-9
        public string TriggerEvent { get; set; } // MSH-9
        public string MessageStructure { get; set; } // MSH-9

        public string AppointmentId { get; set; } // MSH-10
        public string ProcessingID { get; set; } // MSH-11
        public string VersionID { get; set; } // MSH-12
        public string AcceptAcknowledgementType { get; set; } // MSH-15
        public string ApplicationAcknowlegementType { get; set; } // MSH-16
        public string MessageProfileIdentifier { get; set; } // MSH-21

        public string LabName { get; set; }

        // PID Segment
        public string PatientIdentifier { get; set; }
        public string PatientLastName { get; set; } //PID-5-1
        public string PatientFirstName { get; set; }//PID-5-2
        public string PatientMiddleName { get; set; }//PID-5-3
        public string PatientSuffix { get; set; }//PID-5-4
        public string PatientPrefix { get; set; }//PID-5-5
        public string PatientSSN { get; set; }
        public string PatientDOB { get; set; } //PID-7
        public string PatientPhoneHome { get; set; }
        public string PatientPhoneWork { get; set; }
        
        public string PatientGender { get; set; } //PID-8
        public string PatientAddress { get; set; }

        //PV1 Segment
        public string PatientClass { get; set; }
        public string AssignedLocation { get; set; }      
        public string PhysicianAccountNo { get; set; }
        public string PhysicianNpi { get; set; }
        public string PhysicianLastName { get; set; }
        public string PhysicianFirstName { get; set; }
        public string PhysicianMiddleName { get; set; }
        public string PhysicianSuffix { get; set; }
        public string PhysicianPrefix { get; set; }

        //ORC Segment
        public string OrderNumber { get; set; }
        public string OrderingProviderNpi { get; set; }
        public string OrderingProviderLastName { get; set; }
        public string OrderingProviderFirstName { get; set; }
        public string OrderingProviderMiddleName { get; set; }
        public string OrderingProviderSuffix { get; set; }
        public string OrderingProviderPrefix { get; set; }
        public string CollectionDateTime { get; set; }
        public string ExpectedExamDateTime { get; set; }
        public string ProviderLocation { get; set; }
        public string ProviderPhoneNumber { get; set; }

        //OBR Segment
        public string PlacerOrderNumber { get; set; }
        public string SetId { get; set; }
        public string UniversalServiceID { get; set; }
        public string ProcedureCode { get; set; }

        public List<NTE> Comments { get; set; }

    }

    public class NTE
    {
        public string SetId { get; set; }
        public string SourceOfComment { get; set; }
        public string Comment { get; set; }

    }
}