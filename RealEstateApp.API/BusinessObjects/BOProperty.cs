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
    public class BOProperty
    {
        public RealEstateAppContext Db = new RealEstateAppContext();
        public List<Property> Properties { get; set; }
        public Property Property { get; set; }
        public PropertyValidator PropertyValidator { get; set; }

        public BOProperty(Property property)
        {
            Property = property;
            PropertyValidator = new PropertyValidator(Property);
        }

        public BOProperty()
        {
            PropertyValidator = new PropertyValidator();
        }

        public async Task<PetitionResponse> Get()
        {
            List<Property> propertiesList = new List<Property>();
            try
            {
                if (!PropertyValidator.canGetResult())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyValidator.Res,
                        module = "Properties",
                        URL = "api/Property/Get",
                        result = null
                    };
                }
                propertiesList = await Db.Properties.ToListAsync();
                return new PetitionResponse
                {
                    success = true,
                    message = "Dueños listados con éxito",
                    module = "Properties",
                    URL = "api/Property/Get",
                    result = propertiesList
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "Properties",
                    URL = "api/Property/Get",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> GetById(int IdProperty)
        {
            Property property;
            try
            {
                if (!PropertyValidator.canGetResult())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyValidator.Res,
                        module = "Properties",
                        URL = "api/Property/GetById",
                        result = null
                    };
                }
                property = await Db.Properties.Where(x => x.IdProperty == IdProperty).FirstOrDefaultAsync();
                return new PetitionResponse
                {
                    success = true,
                    message = PropertyValidator.Res,
                    module = "Properties",
                    URL = "api/Property/GetById",
                    result = property
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "Properties",
                    URL = "api/Property/GetById",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Add()
        {
            try
            {
                if (PropertyValidator.canSave())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyValidator.Res,
                        module = "Properties",
                        URL = "api/Property/Add",
                        result = null
                    };
                }
                Db.Properties.Add(Property);
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se guardó el dueño en la base de datos",
                        module = "Properties",
                        URL = "api/Property/Add",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Propietario creado con éxito!!",
                    module = "Properties",
                    URL = "api/Property/Add",
                    result = Property
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "Properties",
                    URL = "api/Property/Add",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Update(Property property)
        {
            try
            {
                if (PropertyValidator.canUpdate())
                {
                    return new PetitionResponse
                    {
                        message = PropertyValidator.Res,
                        module = "Properties",
                        URL = "api/Property/Update",
                        result = null
                    };
                }
                Db.Entry(property).State = EntityState.Modified;
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se actualizó el dueño en la base de datos",
                        module = "Properties",
                        URL = "api/Property/Update",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Propietario actualizado con éxito!!",
                    module = "Properties",
                    URL = "api/Property/Update",
                    result = property
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    message = ex.Message,
                    module = "Properties",
                    URL = "api/Property/Update",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Delete(int idProperty)
        {
            try
            {
                if (PropertyValidator.canDelete())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyValidator.Res,
                        module = "Properties",
                        URL = "api/Property/Delete",
                        result = null
                    };
                }
                Property property = await Db.Properties.Where(x => x.IdProperty == idProperty).FirstOrDefaultAsync();
                Db.Properties.Remove(property);
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se pudo eliminar el propietario de la base de datos",
                        module = "Properties",
                        URL = "api/Property/Delete",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Se eliminó el propietario con éxito",
                    module = "Properties",
                    URL = "api/Property/Delete",
                    result = null
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "Properties",
                    URL = "api/Property/Delete",
                    result = null
                };
            }
        }
    }
}
