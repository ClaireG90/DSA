﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFault" in both code and config file together.
    [ServiceContract]
    public interface IFault
    {
        [OperationContract]
        List<Common.Fault> GetAllFaults();

        [OperationContract]
        List<Common.FaultLog> GetAllFaultLogs();

        [OperationContract]
        List<Common.FaultLog> GetAllFaultLogsByFaultID(int id);

        [OperationContract]
        void AddFault(Common.Fault fault);

        [OperationContract]
        void AddFaultLog(Common.FaultLog faultLog);

        [OperationContract]
        int GenerateRandomNumber();

        [OperationContract]
        Common.Fault GetFaultByTicketNumber(int num);

        [OperationContract]
        List<Common.Fault> GetFaultsByAccountID(int aID);

        [OperationContract]
        Common.Fault GetFaultByID(int id);
    }
}
