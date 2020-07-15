using FLA.Core.Domain.Directory;
using FLA.Core.Domain.Permissions;
using FLA.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fla.Service.Common
{
    public class CommonService : ICommonService
    {
        private readonly IRepository<StateProvince> _StateProvienceRepository;
        private readonly IRepository<Role> _RoleProvienceRepository;
        public CommonService(IRepository<StateProvince> StateProvienceRepository, IRepository<Role> RoleProvienceRepository)
        {
            this._StateProvienceRepository = StateProvienceRepository;
            this._RoleProvienceRepository = RoleProvienceRepository;
        }
        public IList<StateProvince> GetState(long CountryId)
        {
            var Query = _StateProvienceRepository.Table.Where(a=>a.CountryId== CountryId);
            return Query.ToList();
        }
        public StateProvince GetStateByid(long stateId)
        {
            var Query = _StateProvienceRepository.Table.Where(a => a.Id == stateId);
            return Query.FirstOrDefault();
        }

        public IList<Role> GetRoleById(long ClientId,long UserId)
        {
            var Query = _RoleProvienceRepository.Table.Where(a => a.ClientId == ClientId && a.UserId==UserId);
            return Query.ToList();
        }
        public Role GetRoleByRoleId( long RoleId)
        {
            var Query = _RoleProvienceRepository.Table.Where(a => a.Id == RoleId);
            return Query.FirstOrDefault();
        }
    }
}
