using FLA.Core.Domain.Clients;
using FLA.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Clients
{
    public  interface iClientService
    {
        #region ClientCode
        string GetMaxClientCode();
        #endregion
        #region Client
        void InsertClient(Client _model);

        void UpdateClient(Client _model);

        void DeleteClient(Client _model);

        IList<Client> GetAllClient(string ClientName = null);

        Client GetClient(long Id = 0);

        Client GetClientById(long Id);
        #endregion
    }
}
