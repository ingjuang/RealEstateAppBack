using RealEstateApp.API.Models;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.API.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateApp.API.Validators;

namespace RealEstateApp.API.BusinessObjects
{
    public class BOOwner
    {
        public RealEstateAppContext Db = new RealEstateAppContext();
        public List<Owner> Owners { get; set; }
        public Owner Owner { get; set; }
        public OwnerValidator OwnerValidator { get; set; }

        public BOOwner(Owner owner)
        {
            Owner = owner;
            OwnerValidator = new OwnerValidator(Owner);
        }

        public BOOwner()
        {
            OwnerValidator = new OwnerValidator();
        }

        public async Task<PetitionResponse> Get()
        {
            List<Owner> ownersList = new List<Owner>();
            try
            {
                if (!OwnerValidator.canGetResult())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = OwnerValidator.Res,
                        module = "Owners",
                        URL = "api/Owner/Get",
                        result = null
                    };
                }
                ownersList = await Db.Owners.ToListAsync();
                return new PetitionResponse
                {
                    success = true,
                    message = "Dueños listados con éxito",
                    module = "Owners",
                    URL = "api/Owner/Get",
                    result = ownersList
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "Owners",
                    URL = "api/Owner/Get",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> GetById(int IdOwner)
        {
            Owner owner;
            try
            {
                if (!OwnerValidator.canGetResult())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = OwnerValidator.Res,
                        module = "Owners",
                        URL = "api/Owner/GetById",
                        result = null
                    };
                }
                owner = await Db.Owners.Where(x => x.IdOwner == IdOwner).FirstOrDefaultAsync();
                return new PetitionResponse
                {
                    success = true,
                    message = OwnerValidator.Res,
                    module = "Owners",
                    URL = "api/Owner/GetById",
                    result = owner
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "Owners",
                    URL = "api/Owner/GetById",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Add()
        {
            try
            {
                if (!OwnerValidator.canSave())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = OwnerValidator.Res,
                        module = "Owners",
                        URL = "api/Owner/Add",
                        result = null
                    };
                }
                Db.Owners.Add(Owner);
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se guardó el dueño en la base de datos",
                        module = "Owners",
                        URL = "api/Owner/Add",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Propietario creado con éxito!!",
                    module = "Owners",
                    URL = "api/Owner/Add",
                    result = Owner
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "Owners",
                    URL = "api/Owner/Add",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Update(Owner owner)
        {
            try
            {
                if (!OwnerValidator.canUpdate())
                {
                    return new PetitionResponse
                    {
                        message = OwnerValidator.Res,
                        module = "Owners",
                        URL = "api/Owner/Update",
                        result = null
                    };
                }
                Db.Entry(owner).State = EntityState.Modified;
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se actualizó el dueño en la base de datos",
                        module = "Owners",
                        URL = "api/Owner/Update",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Propietario actualizado con éxito!!",
                    module = "Owners",
                    URL = "api/Owner/Update",
                    result = owner
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    message = ex.Message,
                    module = "Owners",
                    URL = "api/Owner/Update",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Delete(int idOwner)
        {
            try
            {
                if (!OwnerValidator.canDelete())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = OwnerValidator.Res,
                        module = "Owners",
                        URL = "api/Owner/Delete",
                        result = null
                    };
                }
                Owner owner = await Db.Owners.Where(x => x.IdOwner == idOwner).FirstOrDefaultAsync();
                Db.Owners.Remove(owner);
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se pudo eliminar el propietario de la base de datos",
                        module = "Owners",
                        URL = "api/Owner/Delete",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Se eliminó el propietario con éxito",
                    module = "Owners",
                    URL = "api/Owner/Delete",
                    result = null
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "Owners",
                    URL = "api/Owner/Delete",
                    result = null
                };
            }
        }
    }
}
