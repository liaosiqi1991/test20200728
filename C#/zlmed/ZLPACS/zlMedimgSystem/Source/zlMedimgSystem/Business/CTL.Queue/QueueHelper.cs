using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.DataModel;

namespace zlMedimgSystem.CTL.QueueManager
{
    static public class QueueHelper
    {
        static public string GetLineupStateCaption(LineUpState lineupState)
        {
            switch (lineupState)
            {
                case LineUpState.qsAbandoned: return "已弃呼";
                case LineUpState.qsCalled: return "已呼叫";
                case LineUpState.qsCalling: return "呼叫中";
                case LineUpState.qsPaused: return "已暂停";
                case LineUpState.qsQueueing: return "排队中";
                case LineUpState.qsRecepted: return "已接诊";
                case LineUpState.qsRecepting: return "接诊中";
                case LineUpState.qsReserve: return "占位";
                case LineUpState.qsWaitCall: return "待呼叫";
                default:
                    return "";
            }
        }
    }
}
