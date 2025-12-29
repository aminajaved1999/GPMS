using Entities.GPMS;
using MODEL.GPMS;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.GPMS
{
    public class ShippingMethodManager : DbBase
    {
        /// <summary>
        /// Add new ShippingMethod Info.
        /// </summary>
        /// <param name="pShippingMethodBo"></param>
        /// <returns></returns>
        public CatalogDto AddShippingMethod(ShippingMethodBo pShippingMethodBo)
        {
            var resCatalogDto = new CatalogDto();
            try
            {
                ShippingMethod ShippingMethod = new ShippingMethod();

                // validate
                if (pShippingMethodBo.ShippingMethodCode == null)
                {
                    throw new UserException("Please provide a valid ShippingMethod Code.");
                }
                if (pShippingMethodBo.ShippingMethodName == null)
                {
                    throw new UserException("Please provide a valid ShippingMethod Name.");
                }
                if (pShippingMethodBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                if (pShippingMethodBo.CreatedByID == null)
                {
                    throw new UserException("CreatedByID can't be null");
                }
                // validate

                ShippingMethod.ID = pShippingMethodBo.ID;
                ShippingMethod.ShippingMethodCode = pShippingMethodBo.ShippingMethodCode;
                ShippingMethod.ShippingMethodName = pShippingMethodBo.ShippingMethodName;
                ShippingMethod.Description = pShippingMethodBo.Description;
                ShippingMethod.IsActive = pShippingMethodBo.IsActive;
                ShippingMethod.CreatedBy = pShippingMethodBo.CreatedBy;
                ShippingMethod.CreatedByID = pShippingMethodBo.CreatedByID;
                ShippingMethod.CreatedAt = DateTime.Now;
                ShippingMethod.Notes = pShippingMethodBo.Notes;

                //For POMs
                ShippingMethod.POMs = new List<POM>();
                if (pShippingMethodBo.POMCollection != null && pShippingMethodBo.POMCollection.Count > 0)
                {
                    foreach (var pomBo in pShippingMethodBo.POMCollection)
                    {
                        POM pOM = new POM();
                        pOM.ID = pomBo.ID;
                        ShippingMethod.POMs.Add(pOM);
                    }
                }

                EntitiesContext.ShippingMethods.Add(ShippingMethod); ;
                if (EntitiesContext.SaveChanges() > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pShippingMethodBo.CreatedByID.Value);
                    resCatalogDto.DtoStatus = DtoStatus.Success;
                    resCatalogDto.ShippingMethodBo = new ShippingMethodBo();
                    resCatalogDto.ShippingMethodBo.ID = ShippingMethod.ID;

                }
                else
                {
                    resCatalogDto.DtoStatus = DtoStatus.RecordNotAdded;
                    resCatalogDto.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                }
            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // 2627 mean Violation in unique constraint & 2601 mean duplicate/unique index values
                        {
                            resCatalogDto.DtoStatus = DtoStatus.Error;
                            resCatalogDto.DtoStatusNotes.Exception = "ShippingMethod code already exist.";
                            resCatalogDto.DtoStatusNotes.ExtraNotes.Add("Violation in unique constraint");
                        }
                    }
                    else
                    {
                        resCatalogDto.DtoStatus = DtoStatus.Error;
                        resCatalogDto.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    resCatalogDto.DtoStatus = DtoStatus.Error;
                    resCatalogDto.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                resCatalogDto.DtoStatus = DtoStatus.RecordNotAdded;
                resCatalogDto.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                resCatalogDto.DtoStatus = DtoStatus.Error;
                resCatalogDto.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return resCatalogDto;
        }

        /// <summary>
        /// Update existing ShippingMethod.
        /// </summary>
        /// <param name="pShippingMethodBo"></param>
        /// <returns></returns>
        public CatalogDto UpdateShippingMethod(ShippingMethodBo pShippingMethodBo)
        {
            CommonManager commonManager = new CommonManager();
            var res = new CatalogDto();
            try
            {
                // validate
                if (pShippingMethodBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid ShippingMethod ID.");
                }
                // validate
                if (pShippingMethodBo.ShippingMethodCode == null)
                {
                    throw new UserException("Please provide a valid ShippingMethod Code.");
                }
                if (pShippingMethodBo.ShippingMethodName == null)
                {
                    throw new UserException("Please provide a valid ShippingMethod Name.");
                }
                if (pShippingMethodBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                if (pShippingMethodBo.UpdatedByID == null)
                {
                    throw new UserException("UpdatedByID can't be null");
                }
                // validate

                var retShippingMethod = EntitiesContext.ShippingMethods.Where(x => x.ID == pShippingMethodBo.ID).FirstOrDefault();
                if (retShippingMethod != null)
                {

                    retShippingMethod.ID = pShippingMethodBo.ID;
                    retShippingMethod.ShippingMethodCode = pShippingMethodBo.ShippingMethodCode;
                    retShippingMethod.ShippingMethodName = pShippingMethodBo.ShippingMethodName;
                    retShippingMethod.Description = pShippingMethodBo.Description;
                    retShippingMethod.IsActive = pShippingMethodBo.IsActive;
                    retShippingMethod.UpdatedBy = pShippingMethodBo.UpdatedBy;
                    retShippingMethod.UpdatedByID = pShippingMethodBo.UpdatedByID;
                    retShippingMethod.UpdatedAt = DateTime.Now;
                    retShippingMethod.UpdatedCount = commonManager.IncrementUpdatedCount(retShippingMethod.UpdatedCount);
                    retShippingMethod.Notes = pShippingMethodBo.Notes;

                    //For POMs
                    retShippingMethod.POMs = new List<POM>();
                    if (pShippingMethodBo.POMCollection != null && pShippingMethodBo.POMCollection.Count > 0)
                    {
                        foreach (var pomBo in pShippingMethodBo.POMCollection)
                        {
                            POM pOM = new POM();
                            pOM.ID = pomBo.ID;
                            retShippingMethod.POMs.Add(pOM);
                        }
                    }

                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pShippingMethodBo.UpdatedByID.Value);
                        res.DtoStatus = DtoStatus.Success;

                    }
                    else if (response <= 0)
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdatedWithoutChanges;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdated;
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }

            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = sqlEx.Message.ToString();

                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.Error;
                    res.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.RecordNotUpdated;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// Get ShippingMethod Info against given ShippingMethod Id.
        /// </summary>
        /// <param name="pShippingMethodId"></param>
        /// <returns></returns>
        public CatalogDto GetShippingMethodById(int pShippingMethodId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pShippingMethodId <= 0)
                {
                    throw new UserException("Please provide a valid ShippingMethod ID.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var ShippingMethod = EntitiesContext.ShippingMethods.Where(x => x.ID == pShippingMethodId).FirstOrDefault();
                if (ShippingMethod != null)
                {
                    res.ShippingMethodBo = new ShippingMethodBo();
                    res.ShippingMethodBo.ID = ShippingMethod.ID;
                    res.ShippingMethodBo.ShippingMethodCode = ShippingMethod.ShippingMethodCode;
                    res.ShippingMethodBo.ShippingMethodName = ShippingMethod.ShippingMethodName;
                    res.ShippingMethodBo.Description = ShippingMethod.Description;
                    res.ShippingMethodBo.IsActive = ShippingMethod.IsActive;
                    res.ShippingMethodBo.CreatedBy = ShippingMethod.CreatedBy;
                    res.ShippingMethodBo.CreatedAt = ShippingMethod.CreatedAt;
                    res.ShippingMethodBo.UpdatedBy = ShippingMethod.UpdatedBy;
                    res.ShippingMethodBo.UpdatedAt = ShippingMethod.UpdatedAt;
                    res.ShippingMethodBo.UpdatedCount = ShippingMethod.UpdatedCount;
                    res.ShippingMethodBo.Notes = ShippingMethod.Notes;

                    res.ShippingMethodBo.POMCollection = new List<POMBo>();
                    foreach (var pom in ShippingMethod.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.ShippingMethodBo.POMCollection.Add(pOMBo);
                    }

                    res.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// Get ShippingMethod Info against given ShippingMethod Code.
        /// </summary>
        /// <param name="pShippingMethodCode"></param>
        /// <returns></returns>
        public CatalogDto GetShippingMethodByCode(string pShippingMethodCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pShippingMethodCode == null)
                {
                    throw new UserException("Please provide a valid ShippingMethod Code.");
                }
                // validate
                res.DtoStatus = DtoStatus.Failed;
                var ShippingMethod = EntitiesContext.ShippingMethods.Where(x => x.ShippingMethodCode == pShippingMethodCode).FirstOrDefault();
                if (ShippingMethod != null)
                {
                    res.ShippingMethodBo = new ShippingMethodBo();
                    res.ShippingMethodBo.ID = ShippingMethod.ID;
                    res.ShippingMethodBo.ShippingMethodCode = ShippingMethod.ShippingMethodCode;
                    res.ShippingMethodBo.ShippingMethodName = ShippingMethod.ShippingMethodName;
                    res.ShippingMethodBo.Description = ShippingMethod.Description;
                    res.ShippingMethodBo.IsActive = ShippingMethod.IsActive;
                    res.ShippingMethodBo.CreatedBy = ShippingMethod.CreatedBy;
                    res.ShippingMethodBo.CreatedAt = ShippingMethod.CreatedAt;
                    res.ShippingMethodBo.UpdatedBy = ShippingMethod.UpdatedBy;
                    res.ShippingMethodBo.UpdatedAt = ShippingMethod.UpdatedAt;
                    res.ShippingMethodBo.UpdatedCount = ShippingMethod.UpdatedCount;
                    res.ShippingMethodBo.Notes = ShippingMethod.Notes;

                    res.ShippingMethodBo.POMCollection = new List<POMBo>();
                    foreach (var pom in ShippingMethod.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.ShippingMethodBo.POMCollection.Add(pOMBo);
                    }


                    res.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// To Get all ShippingMethods then pass parameter value as 'null'. 
        /// To Get all active ShippingMethods then pass parameter value as 'true'. 
        /// To Get all In-active ShippingMethods then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllShippingMethods(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<ShippingMethod> ShippingMethodList;
                if (pIsActive.HasValue)
                    ShippingMethodList = EntitiesContext.ShippingMethods.Where(x => x.IsActive == pIsActive).ToList();
                else
                    ShippingMethodList = EntitiesContext.ShippingMethods.ToList();

                if (ShippingMethodList != null && ShippingMethodList.Count > 0)
                {
                    res.ShippingMethodCollection = new List<ShippingMethodBo>();
                    foreach (var ShippingMethod in ShippingMethodList)
                    {
                        ShippingMethodBo ShippingMethodBo = new ShippingMethodBo();
                        ShippingMethodBo.ID = ShippingMethod.ID;
                        ShippingMethodBo.ShippingMethodCode = ShippingMethod.ShippingMethodCode;
                        ShippingMethodBo.ShippingMethodName = ShippingMethod.ShippingMethodName;
                        ShippingMethodBo.Description = ShippingMethod.Description;
                        ShippingMethodBo.IsActive = ShippingMethod.IsActive;
                        ShippingMethodBo.CreatedBy = ShippingMethod.CreatedBy;
                        ShippingMethodBo.CreatedAt = ShippingMethod.CreatedAt;
                        ShippingMethodBo.UpdatedBy = ShippingMethod.UpdatedBy;
                        ShippingMethodBo.UpdatedAt = ShippingMethod.UpdatedAt;
                        ShippingMethodBo.UpdatedCount = ShippingMethod.UpdatedCount;
                        ShippingMethodBo.Notes = ShippingMethod.Notes;

                        ShippingMethodBo.POMCollection = new List<POMBo>();
                        foreach (var pom in ShippingMethod.POMs)
                        {
                            POMBo pOMBo = new POMBo();
                            pOMBo.ID = pom.ID;
                            ShippingMethodBo.POMCollection.Add(pOMBo);
                        }

                        res.ShippingMethodCollection.Add(ShippingMethodBo);

                    }
                    res.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

    }
}
