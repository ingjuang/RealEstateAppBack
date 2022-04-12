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
    public class BOPropertyTrace
    {
        public RealEstateAppContext Db = new RealEstateAppContext();
        public List<PropertyTrace> PropertyTraces { get; set; }
        public PropertyTrace PropertyTrace { get; set; }
        public PropertyTraceValidator PropertyTraceValidator { get; set; }

        public BOPropertyTrace(PropertyTrace propertyTrace)
        {
            PropertyTrace = propertyTrace;
            PropertyTraceValidator = new PropertyTraceValidator(PropertyTrace);
        }

        public BOPropertyTrace()
        {
            PropertyTraceValidator = new PropertyTraceValidator();
        }

        public async Task<PetitionResponse> Get()
        {
            List<PropertyTrace> propertyTracesList = new List<PropertyTrace>();
            try
            {
                if (!PropertyTraceValidator.canGetResult())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyTraceValidator.Res,
                        module = "PropertyTraces",
                        URL = "api/PropertyTrace/Get",
                        result = null
                    };
                }
                propertyTracesList = await Db.PropertyTraces.ToListAsync();
                return new PetitionResponse
                {
                    success = true,
                    message = "Dueños listados con éxito",
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/Get",
                    result = propertyTracesList
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/Get",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> GetById(int IdPropertyTrace)
        {
            PropertyTrace propertyTrace;
            try
            {
                if (!PropertyTraceValidator.canGetResult())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyTraceValidator.Res,
                        module = "PropertyTraces",
                        URL = "api/PropertyTrace/GetById",
                        result = null
                    };
                }
                propertyTrace = await Db.PropertyTraces.Where(x => x.IdPropertyTrace == IdPropertyTrace).FirstOrDefaultAsync();
                return new PetitionResponse
                {
                    success = true,
                    message = PropertyTraceValidator.Res,
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/GetById",
                    result = propertyTrace
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/GetById",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Add()
        {
            try
            {
                if (PropertyTraceValidator.canSave())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyTraceValidator.Res,
                        module = "PropertyTraces",
                        URL = "api/PropertyTrace/Add",
                        result = null
                    };
                }
                Db.PropertyTraces.Add(PropertyTrace);
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se guardó el dueño en la base de datos",
                        module = "PropertyTraces",
                        URL = "api/PropertyTrace/Add",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Propietario creado con éxito!!",
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/Add",
                    result = PropertyTrace
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/Add",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Update(PropertyTrace propertyTrace)
        {
            try
            {
                if (PropertyTraceValidator.canUpdate())
                {
                    return new PetitionResponse
                    {
                        message = PropertyTraceValidator.Res,
                        module = "PropertyTraces",
                        URL = "api/PropertyTrace/Update",
                        result = null
                    };
                }
                Db.Entry(propertyTrace).State = EntityState.Modified;
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se actualizó el dueño en la base de datos",
                        module = "PropertyTraces",
                        URL = "api/PropertyTrace/Update",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Propietario actualizado con éxito!!",
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/Update",
                    result = propertyTrace
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    message = ex.Message,
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/Update",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Delete(int idPropertyTrace)
        {
            try
            {
                if (PropertyTraceValidator.canDelete())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyTraceValidator.Res,
                        module = "PropertyTraces",
                        URL = "api/PropertyTrace/Delete",
                        result = null
                    };
                }
                PropertyTrace propertyTrace = await Db.PropertyTraces.Where(x => x.IdPropertyTrace == idPropertyTrace).FirstOrDefaultAsync();
                Db.PropertyTraces.Remove(propertyTrace);
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se pudo eliminar el propietario de la base de datos",
                        module = "PropertyTraces",
                        URL = "api/PropertyTrace/Delete",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Se eliminó el propietario con éxito",
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/Delete",
                    result = null
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "PropertyTraces",
                    URL = "api/PropertyTrace/Delete",
                    result = null
                };
            }
        }
    }
}
