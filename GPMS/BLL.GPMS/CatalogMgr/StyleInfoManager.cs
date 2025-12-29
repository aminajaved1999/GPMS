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
    public class StyleInfoManager:DbBase
    {
        /// <summary>
        /// Add new Style Info.
        /// </summary>
        /// <param name="pStyleInfoBo"></param>
        /// <returns></returns>
        public CatalogDto AddStyle(StyleInfoBo pStyleInfoBo)
        {
            var resCatalogDto = new CatalogDto();
            try
            {
                StyleInfo StyleInfo = new StyleInfo();
                
                // validate
                if (pStyleInfoBo.CustomerID <= 0)
                {
                    throw new UserException("Please provide a valid Customer ID.");
                }
                if (pStyleInfoBo.StyleCode == null)
                {
                    throw new UserException("Please provide a valid Style Code.");
                }
                if (pStyleInfoBo.StyleName == null)
                {
                    throw new UserException("Please provide a valid Style Name.");
                }
                if (pStyleInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                // validate

                StyleInfo.StyleCode = pStyleInfoBo.StyleCode;
                StyleInfo.StyleName = pStyleInfoBo.StyleName;
                StyleInfo.CustomerID = pStyleInfoBo.CustomerID;
                StyleInfo.Description = pStyleInfoBo.Description;
                StyleInfo.IsActive = pStyleInfoBo.IsActive;
                StyleInfo.CreatedBy = pStyleInfoBo.CreatedBy;
                StyleInfo.CreatedAt = DateTime.Now;
                StyleInfo.UpdatedCount = 0;

                EntitiesContext.StyleInfoes.Add(StyleInfo);
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
                            resCatalogDto.DtoStatusNotes.Exception = "Style code already exist.";
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
        /// Update existing Style.
        /// </summary>
        /// <param name="pStyleInfoBo"></param>
        /// <returns></returns>
        public CatalogDto UpdateStyle(StyleInfoBo pStyleInfoBo)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pStyleInfoBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                if (pStyleInfoBo.CustomerID <= 0)
                {
                    throw new UserException("Please provide a valid Customer ID.");
                }
                if (pStyleInfoBo.StyleCode == null)
                {
                    throw new UserException("Please provide a valid Style Code.");
                }
                if (pStyleInfoBo.StyleName == null)
                {
                    throw new UserException("Please provide a valid Style Name.");
                }
                if (pStyleInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                // validate

                var retStyle = EntitiesContext.StyleInfoes.Where(x => x.ID == pStyleInfoBo.ID).FirstOrDefault();
                if (retStyle != null)
                {
                    retStyle.StyleCode = pStyleInfoBo.StyleCode;
                    retStyle.StyleName = pStyleInfoBo.StyleName;
                    retStyle.CustomerID = pStyleInfoBo.CustomerID;
                    retStyle.Description = pStyleInfoBo.Description;
                    retStyle.IsActive = pStyleInfoBo.IsActive;
                    retStyle.UpdatedBy = pStyleInfoBo.UpdatedBy;
                    retStyle.UpdatedAt = DateTime.Now;
                    retStyle.UpdatedCount = retStyle.UpdatedCount + 1;

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
        /// Get Style Info against given Style Id.
        /// </summary>
        /// <param name="pStyleId"></param>
        /// <returns></returns>
        public CatalogDto GetStyleById(int pStyleId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pStyleId <= 0)
                {
                    throw new UserException("Please provide a valid Style ID.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var Style = EntitiesContext.StyleInfoes.Where(x => x.ID == pStyleId).FirstOrDefault();
                if (Style != null)
                {
                    res.StyleInfoBo = new StyleInfoBo();
                    res.StyleInfoBo.ID = Style.ID;
                    res.StyleInfoBo.StyleCode = Style.StyleCode;
                    res.StyleInfoBo.StyleName = Style.StyleName;
                    res.StyleInfoBo.CustomerID = Style.CustomerID;
                    res.StyleInfoBo.Description = Style.Description;
                    res.StyleInfoBo.IsActive = Style.IsActive;
                    res.StyleInfoBo.CreatedBy = Style.CreatedBy;
                    res.StyleInfoBo.CreatedAt = Style.CreatedAt;
                    res.StyleInfoBo.UpdatedBy = Style.UpdatedBy;
                    res.StyleInfoBo.UpdatedAt = Style.UpdatedAt;
                    res.StyleInfoBo.UpdatedCount = Style.UpdatedCount;
                    res.StyleInfoBo.Notes = Style.Notes;


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
        /// Get Style Info against given Style Code.
        /// </summary>
        /// <param name="pStyleCode"></param>
        /// <returns></returns>
        public CatalogDto GetStyleByCode(string pStyleCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pStyleCode == null)
                {
                    throw new UserException("Please provide a valid Style Code.");
                }
                // validate
                res.DtoStatus = DtoStatus.Failed;
                var Style = EntitiesContext.StyleInfoes.Where(x => x.StyleCode == pStyleCode).FirstOrDefault();
                if (Style != null)
                {
                    res.StyleInfoBo = new StyleInfoBo();
                    res.StyleInfoBo.ID = Style.ID;
                    res.StyleInfoBo.StyleCode = Style.StyleCode;
                    res.StyleInfoBo.StyleName = Style.StyleName;
                    res.StyleInfoBo.CustomerID = Style.CustomerID;
                    res.StyleInfoBo.Description = Style.Description;
                    res.StyleInfoBo.IsActive = Style.IsActive;
                    res.StyleInfoBo.CreatedBy = Style.CreatedBy;
                    res.StyleInfoBo.CreatedAt = Style.CreatedAt;
                    res.StyleInfoBo.UpdatedBy = Style.UpdatedBy;
                    res.StyleInfoBo.UpdatedAt = Style.UpdatedAt;
                    res.StyleInfoBo.UpdatedCount = Style.UpdatedCount;
                    res.StyleInfoBo.Notes = Style.Notes;

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
        /// To Get all Styles then pass parameter value as 'null'. 
        /// To Get all active Styles then pass parameter value as 'true'. 
        /// To Get all In-active Styles then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllStyles(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<StyleInfo> StyleList;
                if (pIsActive.HasValue)
                    StyleList = EntitiesContext.StyleInfoes.Where(x => x.IsActive == pIsActive).ToList();
                else
                    StyleList = EntitiesContext.StyleInfoes.ToList();

                if (StyleList != null && StyleList.Count > 0)
                {
                    res.StyleInfoCollection = new List<StyleInfoBo>();
                    foreach (var Style in StyleList)
                    {
                        StyleInfoBo StyleInfoBo = new StyleInfoBo();
                        StyleInfoBo.ID = Style.ID;
                        StyleInfoBo.StyleCode = Style.StyleCode;
                        StyleInfoBo.StyleName = Style.StyleName;
                        StyleInfoBo.CustomerID = Style.CustomerID;
                        StyleInfoBo.Description = Style.Description;
                        StyleInfoBo.IsActive = Style.IsActive;
                        StyleInfoBo.CreatedBy = Style.CreatedBy;
                        StyleInfoBo.CreatedAt = Style.CreatedAt;
                        StyleInfoBo.UpdatedBy = Style.UpdatedBy;
                        StyleInfoBo.UpdatedAt = Style.UpdatedAt;
                        StyleInfoBo.UpdatedCount = Style.UpdatedCount;
                        StyleInfoBo.Notes = Style.Notes;
                        res.StyleInfoCollection.Add(StyleInfoBo);

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
