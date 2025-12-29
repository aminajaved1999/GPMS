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
    public class ShipmentTermManager : DbBase
    {
        /// <summary>
        /// Get ShipmentTerm Info against given ShipmentTerm Id.
        /// </summary>
        /// <param name="pShipmentTermId"></param>
        /// <returns></returns>
        public CatalogDto GetShipmentTermById(int pShipmentTermId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pShipmentTermId <= 0)
                {
                    throw new UserException("Please provide a valid ShipmentTerm ID.");
                }
                res.DtoStatus = DtoStatus.Failed;
                var ShipmentTerm = EntitiesContext.ShipmentTerms.Where(x => x.ID == pShipmentTermId).FirstOrDefault();
                if (ShipmentTerm != null)
                {
                    res.ShipmentTermBo = new ShipmentTermBo();
                    res.ShipmentTermBo.ID = ShipmentTerm.ID;
                    res.ShipmentTermBo.ShipmentTermCode = ShipmentTerm.ShipmentTermCode;
                    res.ShipmentTermBo.ShipmentTermName = ShipmentTerm.ShipmentTermName;
                    res.ShipmentTermBo.Description = ShipmentTerm.Description;
                    res.ShipmentTermBo.IsActive = ShipmentTerm.IsActive;
                    res.ShipmentTermBo.CreatedBy = ShipmentTerm.CreatedBy;
                    res.ShipmentTermBo.CreatedAt = ShipmentTerm.CreatedAt;
                    res.ShipmentTermBo.UpdatedBy = ShipmentTerm.UpdatedBy;
                    res.ShipmentTermBo.UpdatedAt = ShipmentTerm.UpdatedAt;
                    res.ShipmentTermBo.UpdatedCount = ShipmentTerm.UpdatedCount;
                    res.ShipmentTermBo.Notes = ShipmentTerm.Notes;

                    //for POMCollection
                    res.ShipmentTermBo.POMCollection = new List<POMBo>();
                    foreach (var pom in ShipmentTerm.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.ShipmentTermBo.POMCollection.Add(pOMBo);
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
        /// Get ShipmentTerm Info against given ShipmentTerm Code.
        /// </summary>
        /// <param name="pShipmentTermCode"></param>
        /// <returns></returns>
        public CatalogDto GetShipmentTermByCode(string pShipmentTermCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pShipmentTermCode == null)
                {
                    throw new UserException("Please provide a valid ShipmentTerm Code.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var ShipmentTerm = EntitiesContext.ShipmentTerms.Where(x => x.ShipmentTermCode == pShipmentTermCode).FirstOrDefault();
                if (ShipmentTerm != null)
                {
                    res.ShipmentTermBo = new ShipmentTermBo();
                    res.ShipmentTermBo.ID = ShipmentTerm.ID;
                    res.ShipmentTermBo.ShipmentTermCode = ShipmentTerm.ShipmentTermCode;
                    res.ShipmentTermBo.ShipmentTermName = ShipmentTerm.ShipmentTermName;
                    res.ShipmentTermBo.Description = ShipmentTerm.Description;
                    res.ShipmentTermBo.IsActive = ShipmentTerm.IsActive;
                    res.ShipmentTermBo.CreatedBy = ShipmentTerm.CreatedBy;
                    res.ShipmentTermBo.CreatedAt = ShipmentTerm.CreatedAt;
                    res.ShipmentTermBo.UpdatedBy = ShipmentTerm.UpdatedBy;
                    res.ShipmentTermBo.UpdatedAt = ShipmentTerm.UpdatedAt;
                    res.ShipmentTermBo.UpdatedCount = ShipmentTerm.UpdatedCount;
                    res.ShipmentTermBo.Notes = ShipmentTerm.Notes;

                    //for POMCollection
                    res.ShipmentTermBo.POMCollection = new List<POMBo>();
                    foreach (var pom in ShipmentTerm.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.ShipmentTermBo.POMCollection.Add(pOMBo);
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
        /// To Get all ShipmentTerms then pass parameter value as 'null'. 
        /// To Get all active ShipmentTerms then pass parameter value as 'true'. 
        /// To Get all In-active ShipmentTerms then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllShipmentTerms(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<ShipmentTerm> ShipmentTermList;
                if (pIsActive.HasValue)
                    ShipmentTermList = EntitiesContext.ShipmentTerms.Where(x => x.IsActive == pIsActive).ToList();
                else
                    ShipmentTermList = EntitiesContext.ShipmentTerms.ToList();

                if (ShipmentTermList != null && ShipmentTermList.Count > 0)
                {
                    res.ShipmentTermCollection = new List<ShipmentTermBo>();
                    foreach (var ShipmentTerm in ShipmentTermList)
                    {
                        ShipmentTermBo ShipmentTermBo = new ShipmentTermBo();
                        ShipmentTermBo.ID = ShipmentTerm.ID;
                        ShipmentTermBo.ShipmentTermCode = ShipmentTerm.ShipmentTermCode;
                        ShipmentTermBo.ShipmentTermName = ShipmentTerm.ShipmentTermName;
                        ShipmentTermBo.Description = ShipmentTerm.Description;
                        ShipmentTermBo.IsActive = ShipmentTerm.IsActive;
                        ShipmentTermBo.CreatedBy = ShipmentTerm.CreatedBy;
                        ShipmentTermBo.CreatedAt = ShipmentTerm.CreatedAt;
                        ShipmentTermBo.UpdatedBy = ShipmentTerm.UpdatedBy;
                        ShipmentTermBo.UpdatedAt = ShipmentTerm.UpdatedAt;
                        ShipmentTermBo.UpdatedCount = ShipmentTerm.UpdatedCount;
                        ShipmentTermBo.Notes = ShipmentTerm.Notes;

                        //for POMCollection
                        ShipmentTermBo.POMCollection = new List<POMBo>();
                        foreach (var pom in ShipmentTerm.POMs)
                        {
                            POMBo pOMBo = new POMBo();
                            pOMBo.ID = pom.ID;
                            ShipmentTermBo.POMCollection.Add(pOMBo);
                        }
                        res.ShipmentTermCollection.Add(ShipmentTermBo);

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
