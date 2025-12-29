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
    public class PackingTypeManager : DbBase
    {
        /// <summary>
        /// Get PackingType Info against given PackingType Id.
        /// </summary>
        /// <param name="pPackingTypeId"></param>
        /// <returns></returns>
        public CatalogDto GetPackingTypeById(int pPackingTypeId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPackingTypeId <= 0)
                {
                    throw new UserException("Please provide a valid PackingType ID.");
                }
                res.DtoStatus = DtoStatus.Failed;
                var PackingType = EntitiesContext.PackingTypes.Where(x => x.ID == pPackingTypeId).FirstOrDefault();
                if (PackingType != null)
                {
                    res.PackingTypeBo = new PackingTypeBo();
                    res.PackingTypeBo.ID = PackingType.ID;
                    res.PackingTypeBo.PackingTypeCode = PackingType.PackingTypeCode;
                    res.PackingTypeBo.PackingTypeName = PackingType.PackingTypeName;
                    res.PackingTypeBo.Description = PackingType.Description;
                    res.PackingTypeBo.IsActive = PackingType.IsActive;
                    res.PackingTypeBo.CreatedBy = PackingType.CreatedBy;
                    res.PackingTypeBo.CreatedAt = PackingType.CreatedAt;
                    res.PackingTypeBo.UpdatedBy = PackingType.UpdatedBy;
                    res.PackingTypeBo.UpdatedAt = PackingType.UpdatedAt;
                    res.PackingTypeBo.UpdatedCount = PackingType.UpdatedCount;
                    res.PackingTypeBo.Notes = PackingType.Notes;

                    //for POMCollection
                    res.PackingTypeBo.POMCollection = new List<POMBo>();
                    foreach (var pom in PackingType.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.PackingTypeBo.POMCollection.Add(pOMBo);
                    }
                    //

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
        /// Get PackingType Info against given PackingType Code.
        /// </summary>
        /// <param name="pPackingTypeCode"></param>
        /// <returns></returns>
        public CatalogDto GetPackingTypeByCode(string pPackingTypeCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPackingTypeCode == null)
                {
                    throw new UserException("Please provide a valid PackingType Code.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var PackingType = EntitiesContext.PackingTypes.Where(x => x.PackingTypeCode == pPackingTypeCode).FirstOrDefault();
                if (PackingType != null)
                {

                    res.PackingTypeBo = new PackingTypeBo();
                    res.PackingTypeBo.ID = PackingType.ID;
                    res.PackingTypeBo.PackingTypeCode = PackingType.PackingTypeCode;
                    res.PackingTypeBo.PackingTypeName = PackingType.PackingTypeName;
                    res.PackingTypeBo.Description = PackingType.Description;
                    res.PackingTypeBo.IsActive = PackingType.IsActive;
                    res.PackingTypeBo.CreatedBy = PackingType.CreatedBy;
                    res.PackingTypeBo.CreatedAt = PackingType.CreatedAt;
                    res.PackingTypeBo.UpdatedBy = PackingType.UpdatedBy;
                    res.PackingTypeBo.UpdatedAt = PackingType.UpdatedAt;
                    res.PackingTypeBo.UpdatedCount = PackingType.UpdatedCount;
                    res.PackingTypeBo.Notes = PackingType.Notes;

                    //for POMCollection
                    res.PackingTypeBo.POMCollection = new List<POMBo>();
                    foreach (var pom in PackingType.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.PackingTypeBo.POMCollection.Add(pOMBo);
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
        /// To Get all PackingTypes then pass parameter value as 'null'. 
        /// To Get all active PackingTypes then pass parameter value as 'true'. 
        /// To Get all In-active PackingTypes then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllPackingTypes(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<PackingType> PackingTypeList;
                if (pIsActive.HasValue)
                    PackingTypeList = EntitiesContext.PackingTypes.Where(x => x.IsActive == pIsActive).ToList();
                else
                    PackingTypeList = EntitiesContext.PackingTypes.ToList();

                if (PackingTypeList != null && PackingTypeList.Count > 0)
                {
                    res.PackingTypeCollection = new List<PackingTypeBo>();
                    foreach (var PackingType in PackingTypeList)
                    {
                        PackingTypeBo PackingTypeBo = new PackingTypeBo();
                        PackingTypeBo.ID = PackingType.ID;
                        PackingTypeBo.PackingTypeCode = PackingType.PackingTypeCode;
                        PackingTypeBo.PackingTypeName = PackingType.PackingTypeName;
                        PackingTypeBo.Description = PackingType.Description;
                        PackingTypeBo.IsActive = PackingType.IsActive;
                        PackingTypeBo.CreatedBy = PackingType.CreatedBy;
                        PackingTypeBo.CreatedAt = PackingType.CreatedAt;
                        PackingTypeBo.UpdatedBy = PackingType.UpdatedBy;
                        PackingTypeBo.UpdatedAt = PackingType.UpdatedAt;
                        PackingTypeBo.UpdatedCount = PackingType.UpdatedCount;
                        PackingTypeBo.Notes = PackingType.Notes;

                        //for POMCollection
                        PackingTypeBo.POMCollection = new List<POMBo>();
                        foreach (var pom in PackingType.POMs)
                        {
                            POMBo pOMBo = new POMBo();
                            pOMBo.ID = pom.ID;
                            PackingTypeBo.POMCollection.Add(pOMBo);
                        }
                        res.PackingTypeCollection.Add(PackingTypeBo);

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
