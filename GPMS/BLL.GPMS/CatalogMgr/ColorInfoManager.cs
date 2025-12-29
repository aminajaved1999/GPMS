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
    public class ColorInfoManager : DbBase
    {
        /// <summary>
        /// Add new Color.
        /// </summary>
        /// <param name="pColorInfoBo"></param>
        /// <returns></returns>
        public CatalogDto AddColor(ColorInfoBo pColorInfoBo)
        {
            var resCatalogDto = new CatalogDto();
            try
            {
                ColorInfo ColorInfo = new ColorInfo();

                // validate
                if (pColorInfoBo.CustomerID <= 0)
                {
                    throw new UserException("Please provide a valid Customer ID.");
                }
                if (pColorInfoBo.ColorCode == null)
                {
                    throw new UserException("Please provide a valid Color Code.");
                }
                if (pColorInfoBo.ColorName == null)
                {
                    throw new UserException("Please provide a valid Color Name.");
                }
                if (pColorInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                // validate

                ColorInfo.ColorCode = pColorInfoBo.ColorCode;
                ColorInfo.ColorName = pColorInfoBo.ColorName;
                ColorInfo.CustomerID = pColorInfoBo.CustomerID;
                ColorInfo.Description = pColorInfoBo.Description;
                ColorInfo.IsActive = pColorInfoBo.IsActive;
                ColorInfo.CreatedBy = pColorInfoBo.CreatedBy;
                ColorInfo.CreatedAt = DateTime.Now;
                ColorInfo.UpdatedCount = 0;

                EntitiesContext.ColorInfoes.Add(ColorInfo);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    resCatalogDto.DtoStatus = DtoStatus.Success;

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
                            resCatalogDto.DtoStatusNotes.Exception = "Color code already exist.";
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
        /// Update existing Color.
        /// </summary>
        /// <param name="pColorInfoBo"></param>
        /// <returns></returns>
        public CatalogDto UpdateColor(ColorInfoBo pColorInfoBo)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pColorInfoBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid Color ID.");
                }
                if (pColorInfoBo.CustomerID <= 0)
                {
                    throw new UserException("Please provide a valid Customer ID.");
                }
                if (pColorInfoBo.ColorCode == null)
                {
                    throw new UserException("Please provide a valid Color Code.");
                }
                if (pColorInfoBo.ColorName == null)
                {
                    throw new UserException("Please provide a valid Color Name.");
                }
                if (pColorInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                // validate

                var retColor = EntitiesContext.ColorInfoes.Where(x => x.ID == pColorInfoBo.ID).FirstOrDefault();
                if (retColor != null)
                {
                    retColor.ColorCode = pColorInfoBo.ColorCode;
                    retColor.ColorName = pColorInfoBo.ColorName;
                    retColor.CustomerID = pColorInfoBo.CustomerID;
                    retColor.Description = pColorInfoBo.Description;
                    retColor.IsActive = pColorInfoBo.IsActive;
                    retColor.UpdatedBy = pColorInfoBo.UpdatedBy;
                    retColor.UpdatedAt = DateTime.Now;
                    retColor.UpdatedCount = retColor.UpdatedCount + 1;

                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
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
        /// Get Color Info against given Color Id.
        /// </summary>
        /// <param name="pColorId"></param>
        /// <returns></returns>
        public CatalogDto GetColorById(int pColorId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pColorId <= 0)
                {
                    throw new UserException("Please provide a valid Color Id.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var Color = EntitiesContext.ColorInfoes.Where(x => x.ID == pColorId).FirstOrDefault();
                if (Color != null)
                {
                    res.ColorInfoBo = new ColorInfoBo();
                    res.ColorInfoBo.ID = Color.ID;
                    res.ColorInfoBo.ColorCode = Color.ColorCode;
                    res.ColorInfoBo.ColorName = Color.ColorName;
                    res.ColorInfoBo.CustomerID = Color.CustomerID;
                    res.ColorInfoBo.Description = Color.Description;
                    res.ColorInfoBo.IsActive = Color.IsActive;
                    res.ColorInfoBo.CreatedBy = Color.CreatedBy;
                    res.ColorInfoBo.CreatedAt = Color.CreatedAt;
                    res.ColorInfoBo.UpdatedBy = Color.UpdatedBy;
                    res.ColorInfoBo.UpdatedAt = Color.UpdatedAt;
                    res.ColorInfoBo.UpdatedCount = Color.UpdatedCount;
                    res.ColorInfoBo.Notes = Color.Notes;


                    res.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.RecordNotAdded;
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
        /// Get Color Info against given Color Code.
        /// </summary>
        /// <param name="pColorId"></param>
        /// <returns></returns>
        public CatalogDto GetColorByCode(string pColorCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pColorCode == null)
                {
                    throw new UserException("Please provide a valid Color Id.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var Color = EntitiesContext.ColorInfoes.Where(x => x.ColorCode == pColorCode).FirstOrDefault();
                if (Color != null)
                {
                    res.ColorInfoBo = new ColorInfoBo();
                    res.ColorInfoBo.ID = Color.ID;
                    res.ColorInfoBo.ColorCode = Color.ColorCode;
                    res.ColorInfoBo.ColorName = Color.ColorName;
                    res.ColorInfoBo.CustomerID = Color.CustomerID;
                    res.ColorInfoBo.Description = Color.Description;
                    res.ColorInfoBo.IsActive = Color.IsActive;
                    res.ColorInfoBo.CreatedBy = Color.CreatedBy;
                    res.ColorInfoBo.CreatedAt = Color.CreatedAt;
                    res.ColorInfoBo.UpdatedBy = Color.UpdatedBy;
                    res.ColorInfoBo.UpdatedAt = Color.UpdatedAt;
                    res.ColorInfoBo.UpdatedCount = Color.UpdatedCount;
                    res.ColorInfoBo.Notes = Color.Notes;


                    res.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.RecordNotAdded;
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
        /// To Get all Colors then pass parameter value as 'null'. 
        /// To Get all active Colors then pass parameter value as 'true'. 
        /// To Get all In-active Colors then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllColors(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<ColorInfo> ColorList;
                if (pIsActive.HasValue)
                    ColorList = EntitiesContext.ColorInfoes.Where(x => x.IsActive == pIsActive).ToList();
                else
                    ColorList = EntitiesContext.ColorInfoes.ToList();

                if (ColorList != null && ColorList.Count > 0)
                {
                    res.ColorInfoCollection = new List<ColorInfoBo>();
                    foreach (var Color in ColorList)
                    {
                        ColorInfoBo ColorInfoBo = new ColorInfoBo();
                        ColorInfoBo.ID = Color.ID;
                        ColorInfoBo.ColorCode = Color.ColorCode;
                        ColorInfoBo.ColorName = Color.ColorName;
                        ColorInfoBo.CustomerID = Color.CustomerID;
                        ColorInfoBo.Description = Color.Description;
                        ColorInfoBo.IsActive = Color.IsActive;
                        ColorInfoBo.CreatedBy = Color.CreatedBy;
                        ColorInfoBo.CreatedAt = Color.CreatedAt;
                        ColorInfoBo.UpdatedBy = Color.UpdatedBy;
                        ColorInfoBo.UpdatedAt = Color.UpdatedAt;
                        ColorInfoBo.UpdatedCount = Color.UpdatedCount;
                        ColorInfoBo.Notes = Color.Notes;
                        res.ColorInfoCollection.Add(ColorInfoBo);

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
                res.DtoStatus = DtoStatus.RecordNotAdded;
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
