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
    public class BOPropertyImage
    {
        public RealEstateAppContext Db = new RealEstateAppContext();
        public List<PropertyImage> PropertyImages { get; set; }
        public PropertyImage PropertyImage { get; set; }
        public PropertyImageValidator PropertyImageValidator { get; set; }

        public BOPropertyImage(PropertyImage propertyImage)
        {
            PropertyImage = propertyImage;
            PropertyImageValidator = new PropertyImageValidator(PropertyImage);
        }

        public BOPropertyImage()
        {
            PropertyImageValidator = new PropertyImageValidator();
        }

        public async Task<PetitionResponse> Get(int idProperty)
        {
            List<PropertyImage> propertyImagesList = new List<PropertyImage>();
            try
            {
                if (!PropertyImageValidator.canGetResult())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyImageValidator.Res,
                        module = "PropertyImages",
                        URL = "api/PropertyImage/Get",
                        result = null
                    };
                }
                propertyImagesList = await Db.PropertyImages.Where(x => x.IdProperty == idProperty).ToListAsync();
                return new PetitionResponse
                {
                    success = true,
                    message = "Dueños listados con éxito",
                    module = "PropertyImages",
                    URL = "api/PropertyImage/Get",
                    result = propertyImagesList
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "PropertyImages",
                    URL = "api/PropertyImage/Get",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> GetById(int IdPropertyImage)
        {
            PropertyImage propertyImage;
            try
            {
                if (!PropertyImageValidator.canGetResult())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyImageValidator.Res,
                        module = "PropertyImages",
                        URL = "api/PropertyImage/GetById",
                        result = null
                    };
                }
                propertyImage = await Db.PropertyImages.Where(x => x.IdPropertyImage == IdPropertyImage).FirstOrDefaultAsync();
                return new PetitionResponse
                {
                    success = true,
                    message = PropertyImageValidator.Res,
                    module = "PropertyImages",
                    URL = "api/PropertyImage/GetById",
                    result = propertyImage
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "PropertyImages",
                    URL = "api/PropertyImage/GetById",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Add()
        {
            try
            {
                if (!PropertyImageValidator.canSave())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyImageValidator.Res,
                        module = "PropertyImages",
                        URL = "api/PropertyImage/Add",
                        result = null
                    };
                }
                var propertiesImage = Db.PropertyImages.OrderByDescending(x => x.IdPropertyImage).FirstOrDefault();
                PropertyImage.IdPropertyImage = propertiesImage.IdPropertyImage + 1;
                Db.PropertyImages.Add(PropertyImage);
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se guardó el dueño en la base de datos",
                        module = "PropertyImages",
                        URL = "api/PropertyImage/Add",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Propietario creado con éxito!!",
                    module = "PropertyImages",
                    URL = "api/PropertyImage/Add",
                    result = PropertyImage
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "PropertyImages",
                    URL = "api/PropertyImage/Add",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Update(PropertyImage propertyImage)
        {
            try
            {
                if (!PropertyImageValidator.canUpdate())
                {
                    return new PetitionResponse
                    {
                        message = PropertyImageValidator.Res,
                        module = "PropertyImages",
                        URL = "api/PropertyImage/Update",
                        result = null
                    };
                }
                Db.Entry(propertyImage).State = EntityState.Modified;
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se actualizó el dueño en la base de datos",
                        module = "PropertyImages",
                        URL = "api/PropertyImage/Update",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Propietario actualizado con éxito!!",
                    module = "PropertyImages",
                    URL = "api/PropertyImage/Update",
                    result = propertyImage
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    message = ex.Message,
                    module = "PropertyImages",
                    URL = "api/PropertyImage/Update",
                    result = null
                };
            }
        }

        public async Task<PetitionResponse> Delete(int idPropertyImage)
        {
            try
            {
                if (!PropertyImageValidator.canDelete())
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = PropertyImageValidator.Res,
                        module = "PropertyImages",
                        URL = "api/PropertyImage/Delete",
                        result = null
                    };
                }
                PropertyImage propertyImage = await Db.PropertyImages.Where(x => x.IdPropertyImage == idPropertyImage).FirstOrDefaultAsync();
                Db.PropertyImages.Remove(propertyImage);
                if (await Db.SaveChangesAsync() <= 0)
                {
                    return new PetitionResponse
                    {
                        success = false,
                        message = "No se pudo eliminar el propietario de la base de datos",
                        module = "PropertyImages",
                        URL = "api/PropertyImage/Delete",
                        result = null
                    };
                }
                return new PetitionResponse
                {
                    success = true,
                    message = "Se eliminó el propietario con éxito",
                    module = "PropertyImages",
                    URL = "api/PropertyImage/Delete",
                    result = null
                };
            }
            catch (Exception ex)
            {
                return new PetitionResponse
                {
                    success = false,
                    message = ex.Message,
                    module = "PropertyImages",
                    URL = "api/PropertyImage/Delete",
                    result = null
                };
            }
        }
    }
}
