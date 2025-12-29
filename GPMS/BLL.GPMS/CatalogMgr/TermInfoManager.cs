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
    public class TermInfoManager:DbBase
    {

        /// <summary>
        /// Add new Term Info.
        /// </summary>
        /// <param name="pTermInfoBo"></param>
        /// <returns></returns>
        public CatalogDto AddTerm(TermInfoBo pTermInfoBo)
        {
            var resCatalogDto = new CatalogDto();
            try
            {
                TermInfo TermInfo = new TermInfo();
                
                // validate
                if (pTermInfoBo.TermCode == null)
                {
                    throw new UserException("Please provide a valid Term Code.");
                }
                if (pTermInfoBo.TermName == null)
                {
                    throw new UserException("Please provide a valid Term Name.");
                }
                if (pTermInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                // validate


                TermInfo.TermCode = pTermInfoBo.TermCode;
                TermInfo.TermName = pTermInfoBo.TermName;
                TermInfo.Days = pTermInfoBo.Days;
                TermInfo.PenaltyPercentage = pTermInfoBo.PenaltyPercentage;
                TermInfo.Description = pTermInfoBo.Description;
                TermInfo.IsActive = pTermInfoBo.IsActive;
                TermInfo.CreatedBy = pTermInfoBo.CreatedBy;
                TermInfo.CreatedAt = DateTime.Now;
                TermInfo.UpdatedCount = 0;

                EntitiesContext.TermInfoes.Add(TermInfo);
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
                            resCatalogDto.DtoStatusNotes.Exception = "Term code already exist.";
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
        /// Update existing Term.
        /// </summary>
        /// <param name="pTermInfoBo"></param>
        /// <returns></returns>
        public CatalogDto UpdateTerm(TermInfoBo pTermInfoBo)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pTermInfoBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid Term ID.");
                }
                if (pTermInfoBo.TermCode == null)
                {
                    throw new UserException("Please provide a valid Term Code.");
                }
                if (pTermInfoBo.TermName == null)
                {
                    throw new UserException("Please provide a valid Term Name.");
                }
                if (pTermInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                // validate

                var retTerm = EntitiesContext.TermInfoes.Where(x => x.ID == pTermInfoBo.ID).FirstOrDefault();
                if (retTerm != null)
                {
                    retTerm.TermCode = pTermInfoBo.TermCode;
                    retTerm.TermName = pTermInfoBo.TermName;
                    retTerm.Days = pTermInfoBo.Days;
                    retTerm.PenaltyPercentage = pTermInfoBo.PenaltyPercentage;
                    retTerm.Description = pTermInfoBo.Description;
                    retTerm.IsActive = pTermInfoBo.IsActive;
                    retTerm.UpdatedBy = pTermInfoBo.UpdatedBy;
                    retTerm.UpdatedAt = DateTime.Now;
                    retTerm.UpdatedCount = retTerm.UpdatedCount + 1;

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
        /// Get Term Info against given Term Id.
        /// </summary>
        /// <param name="pTermId"></param>
        /// <returns></returns>
        public CatalogDto GetTermById(int pTermId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pTermId <= 0)
                {
                    throw new UserException("Please provide a valid Term ID.");
                }
                res.DtoStatus = DtoStatus.Failed;
                var Term = EntitiesContext.TermInfoes.Where(x => x.ID == pTermId).FirstOrDefault();
                if (Term != null)
                {
                    res.TermInfoBo = new TermInfoBo();
                    res.TermInfoBo.ID = Term.ID;
                    res.TermInfoBo.TermCode = Term.TermCode;
                    res.TermInfoBo.TermName = Term.TermName;
                    res.TermInfoBo.Days = Term.Days;
                    res.TermInfoBo.PenaltyPercentage = Term.PenaltyPercentage;
                    res.TermInfoBo.Description = Term.Description;
                    res.TermInfoBo.IsActive = Term.IsActive;
                    res.TermInfoBo.CreatedBy = Term.CreatedBy;
                    res.TermInfoBo.CreatedAt = Term.CreatedAt;
                    res.TermInfoBo.UpdatedBy = Term.UpdatedBy;
                    res.TermInfoBo.UpdatedAt = Term.UpdatedAt;
                    res.TermInfoBo.UpdatedCount = Term.UpdatedCount;
                    res.TermInfoBo.Notes = Term.Notes;

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
        /// Get Term Info against given Term Code.
        /// </summary>
        /// <param name="pTermCode"></param>
        /// <returns></returns>
        public CatalogDto GetTermByCode(string pTermCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pTermCode == null)
                {
                    throw new UserException("Please provide a valid Term Code.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var Term = EntitiesContext.TermInfoes.Where(x => x.TermCode == pTermCode).FirstOrDefault();
                if (Term != null)
                {
                    res.TermInfoBo = new TermInfoBo();
                    res.TermInfoBo.ID = Term.ID;
                    res.TermInfoBo.TermCode = Term.TermCode;
                    res.TermInfoBo.TermName = Term.TermName;
                    res.TermInfoBo.Days = Term.Days;
                    res.TermInfoBo.PenaltyPercentage = Term.PenaltyPercentage;
                    res.TermInfoBo.Description = Term.Description;
                    res.TermInfoBo.IsActive = Term.IsActive;
                    res.TermInfoBo.CreatedBy = Term.CreatedBy;
                    res.TermInfoBo.CreatedAt = Term.CreatedAt;
                    res.TermInfoBo.UpdatedBy = Term.UpdatedBy;
                    res.TermInfoBo.UpdatedAt = Term.UpdatedAt;
                    res.TermInfoBo.UpdatedCount = Term.UpdatedCount;
                    res.TermInfoBo.Notes = Term.Notes;


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
        /// To Get all Terms then pass parameter value as 'null'. 
        /// To Get all active Terms then pass parameter value as 'true'. 
        /// To Get all In-active Terms then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllTerms(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<TermInfo> TermList;
                if (pIsActive.HasValue)
                    TermList = EntitiesContext.TermInfoes.Where(x => x.IsActive == pIsActive).ToList();
                else
                    TermList = EntitiesContext.TermInfoes.ToList();

                if (TermList != null && TermList.Count > 0)
                {
                    res.TermInfoCollection = new List<TermInfoBo>();
                    foreach (var Term in TermList)
                    {
                        TermInfoBo TermInfoBo = new TermInfoBo();
                        TermInfoBo.ID = Term.ID;
                        TermInfoBo.TermCode = Term.TermCode;
                        TermInfoBo.TermName = Term.TermName;
                        TermInfoBo.Days = Term.Days;
                        TermInfoBo.PenaltyPercentage = Term.PenaltyPercentage;
                        TermInfoBo.Description = Term.Description;
                        TermInfoBo.IsActive = Term.IsActive;
                        TermInfoBo.CreatedBy = Term.CreatedBy;
                        TermInfoBo.CreatedAt = Term.CreatedAt;
                        TermInfoBo.UpdatedBy = Term.UpdatedBy;
                        TermInfoBo.UpdatedAt = Term.UpdatedAt;
                        TermInfoBo.UpdatedCount = Term.UpdatedCount;
                        TermInfoBo.Notes = Term.Notes;
                        res.TermInfoCollection.Add(TermInfoBo);
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
