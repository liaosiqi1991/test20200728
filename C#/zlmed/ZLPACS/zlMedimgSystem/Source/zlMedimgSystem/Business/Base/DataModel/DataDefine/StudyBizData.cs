using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.DataModel
{
    public class StudyBizData : IStudyBizData
    {

        public int StudyId
        {
            get;
            set;
        }

        public int PatientId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public string Sex
        {
            get;
            set;
        }
        public string StudyNo
        {
            get;
            set;
        }

        public string InHospitalNo
        {
            get;
            set;
        }

        public string OutHospitalNo
        {
            get;
            set;
        }

        public string ItemContext
        {
            get;
            set;
        }
        public string FmtRecDate
        {
            get;
            set;
        }

        public object JSonInfos
        {
            get;
            set;
        }
    }
}
