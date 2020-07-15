using FLA.Core.Domain.Clients;
using FLA.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fla.Service.Clients
{
   public class ClientService:iClientService
    {
        #region Repos
        private readonly IRepository<Client> _ClientRepository;
        private readonly IRepository<FactorCompany> _FactorCompanyRepository;
        #endregion
        #region Ctor
        public ClientService(IRepository<Client> ClientRepository, IRepository<FactorCompany> FactorCompanyRepository)
        {
            this._ClientRepository = ClientRepository;
            this._FactorCompanyRepository = FactorCompanyRepository;
        }
        #endregion
        #region Client
        public string GetMaxClientCode()
        {
            string code = "";
            var quary = _ClientRepository.Table.OrderByDescending(a => a.Id).FirstOrDefault();
            if (quary == null)
            {
                code = "FLA0001";
            }
            else
            {
                var number = Convert.ToInt32(quary.ClientCode.Substring(3, 4)) + 1;
                var count = number.ToString().Length;
                code = (count == 1 ? "FLA000" + number : (count == 2 ? "FLA00" + number : (count == 3 ? "FLA0" + number : "FLA" + number))).ToString();
            }
            return code;
        }
        public IList<Client> GetAllClient(string ClientName = null)
        {
            var quary = _ClientRepository.Table;
            if (ClientName != null)
            {
                quary = quary.Where(a => a.Name.Contains(ClientName));
            }


            return quary.ToList();
        }
        public Client GetClient(long Id)
        {
            var quary = _ClientRepository.Table;

            if (Id != 0)
            {
                quary = quary.Where(a => a.Id == Id);
            }
            return quary.FirstOrDefault();
        }
        public Client GetClientById(long Id)
        {
            var quary = _ClientRepository.Table.Where(a => a.Id == Id);


            return quary.FirstOrDefault();
        }
        public void InsertClient(Client _Client)
        {
            if (_Client == null)
                throw new ArgumentNullException(nameof(_Client));
            _ClientRepository.Insert(_Client);
        }
        public void UpdateClient(Client _Client)
        {
            if (_Client == null)
                throw new ArgumentNullException(nameof(_Client));
            _ClientRepository.Update(_Client);
        }
        public void DeleteClient(Client _Client)
        {
            if (_Client == null)
                throw new ArgumentNullException(nameof(_Client));
            _ClientRepository.Delete(_Client);
        }

        #endregion
    }
}
