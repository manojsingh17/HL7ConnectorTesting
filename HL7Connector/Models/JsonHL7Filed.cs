using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7CreationFromJson
{
    public class JsonHL7Fields
    {
        public JsonHL7Fields()
        {
            Icd10Codes = new List<string>();
            QuestionAnswer = new List<KeyValuePair<string, string>>();
        }
        public string SendingApplication { get; set; } // MSH-3
        public string SendingFacility { get; set; } //MSH-4 
        public string ReceivingApplication { get; set; } //MSH-5
        public string ReceivingFacility { get; set; } // MSH-6

        public string MessageCode { get; set; } // MSH-9
        public string TriggerEvent { get; set; } // MSH-9
        public string MessageStructure { get; set; } // MSH-9

        public string MessageControlId { get; set; } // MSH-10
        public string ProcessingID { get; set; } // MSH-11
        public string VersionID { get; set; } // MSH-12
        public string AcceptAcknowledgementType { get; set; } // MSH-15
        public string ApplicationAcknowlegementType { get; set; } // MSH-16
        public string MessageProfileIdentifier { get; set; } // MSH-21

        public string LabName { get; set; }

        // PID Segment
        public string PatientLastName { get; set; } //PID-5-1
        public string PatientFirstName { get; set; }//PID-5-2
        public string PatientSSN { get; set; }
        public string PatientDOB { get; set; } //PID-7
        public string PatientPhoneHome { get; set; }
        public string PatientPhoneWork { get; set; }
        public string PatientChartNo { get; set; }
        public string PatientGender { get; set; } //PID-8
        public string PatientAddress { get; set; }

        //PV1 Segment
        public string PhysicianName { get; set; }
        public string PhysicianAccountNo { get; set; }
        public string PhysicianNpi { get; set; }

        public string InsuranceName { get; set; }
        public string InsurancePolicy { get; set; }
        public string InsuranceGroup { get; set; }
        public string InsuredName { get; set; }
        public string InsuredSSN { get; set; }
        public string InsuredDob { get; set; }
        public string RelationToPatient { get; set; }

        public string CollectionDateTime { get; set; }

        public List<string> Icd10Codes { get; set; }
        public List<KeyValuePair<string, string>> QuestionAnswer { get; set; }

    }
}