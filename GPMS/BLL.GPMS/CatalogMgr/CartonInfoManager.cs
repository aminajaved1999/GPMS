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
    public class CartonInfoManager : DbBase
    {
        /// <summary>
        /// Add new CartonInfo.
        /// </summary>
        /// <param name="pCartonInfoBo"></param>
        /// <returns></returns>
        public CatalogDto AddCarton(CartonInfoBo pCartonInfoBo)
        {
            var resCatalogDto = new CatalogDto();
            try
            {

                CartonInfo CartonInfo = new CartonInfo();

                // validate
                if (pCartonInfoBo.CustomerID <= 0)
                {
                    throw new UserException("Please provide a valid Customer ID.");
                }
                if (pCartonInfoBo.CartonCode == null)
                {
                    throw new UserException("Please provide a valid Carton Code.");
                }
                if (pCartonInfoBo.CartonName == null)
                {
                    throw new UserException("Please provide a valid Carton Name.");
                }
                if (pCartonInfoBo.Length <= 0)
                {
                    throw new UserException("Please provide a valid Length.");
                }
                if (pCartonInfoBo.Width <= 0)
                {
                    throw new UserException("Please provide a valid Width.");
                }
                if (pCartonInfoBo.Height <= 0)
                {
                    throw new UserException("Please provide a valid Height.");
                }
                if (pCartonInfoBo.Weight <= 0)
                {
                    throw new UserException("Please provide a valid Weight.");
                }
                if (pCartonInfoBo.CBM <= 0)
                {
                    throw new UserException("Please provide a valid CBM.");
                }
                if (pCartonInfoBo.LengthUomID <= 0)
                {
                    throw new UserException("Please provide a valid LengthUomID.");
                }
                if (pCartonInfoBo.WidthUomID <= 0)
                {
                    throw new UserException("Please provide a valid WidthUomID.");
                }
                if (pCartonInfoBo.HeightUomID <= 0)
                {
                    throw new UserException("Please provide a valid HeightUomID.");
                }
                if (pCartonInfoBo.WeightUomID <= 0)
                {
                    throw new UserException("Please provide a valid WeightUomID.");
                }
                if (pCartonInfoBo.CBMUomID <= 0)
                {
                    throw new UserException("Please provide a valid CBMUomID.");
                }
                if (pCartonInfoBo.Priority <= 0)
                {
                    throw new UserException("Please provide a valid Priority.");
                }
                if (pCartonInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                // validate

                CartonInfo.CartonCode = pCartonInfoBo.CartonCode;
                CartonInfo.CartonName = pCartonInfoBo.CartonName;
                CartonInfo.Length = pCartonInfoBo.Length;
                CartonInfo.Width = pCartonInfoBo.Width;
                CartonInfo.Height = pCartonInfoBo.Height;
                CartonInfo.Weight = pCartonInfoBo.Weight;
                CartonInfo.CBM = pCartonInfoBo.CBM;
                CartonInfo.LengthUomID = pCartonInfoBo.LengthUomID;
                CartonInfo.WidthUomID = pCartonInfoBo.WidthUomID;
                CartonInfo.HeightUomID = pCartonInfoBo.HeightUomID;
                CartonInfo.WeightUomID = pCartonInfoBo.WeightUomID;
                CartonInfo.CBMUomID = pCartonInfoBo.CBMUomID;
                CartonInfo.Priority = pCartonInfoBo.Priority;
                CartonInfo.Description = pCartonInfoBo.Description;
                CartonInfo.IsActive = pCartonInfoBo.IsActive;
                CartonInfo.CreatedBy = pCartonInfoBo.CreatedBy;
                CartonInfo.CreatedAt = DateTime.Now;
                CartonInfo.UpdatedCount = 0;

                EntitiesContext.CartonInfoes.Add(CartonInfo);
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
                            resCatalogDto.DtoStatusNotes.Exception = "Carton code already exist.";
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
        /// Update existing CartonInfo.
        /// </summary>
        /// <param name="pCartonInfoBo"></param>
        /// <returns></returns>
        public CatalogDto UpdateCarton(CartonInfoBo pCartonInfoBo)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pCartonInfoBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid Carton ID.");
                }
                if (pCartonInfoBo.CustomerID <= 0)
                {
                    throw new UserException("Please provide a valid Customer ID.");
                }
                if (pCartonInfoBo.CartonCode == null)
                {
                    throw new UserException("Please provide a valid Carton Code.");
                }
                if (pCartonInfoBo.CartonName == null)
                {
                    throw new UserException("Please provide a valid Carton Name.");
                }
                if (pCartonInfoBo.Length <= 0)
                {
                    throw new UserException("Please provide a valid Length.");
                }
                if (pCartonInfoBo.Width <= 0)
                {
                    throw new UserException("Please provide a valid Width.");
                }
                if (pCartonInfoBo.Height <= 0)
                {
                    throw new UserException("Please provide a valid Height.");
                }
                if (pCartonInfoBo.Weight <= 0)
                {
                    throw new UserException("Please provide a valid Weight.");
                }
                if (pCartonInfoBo.CBM <= 0)
                {
                    throw new UserException("Please provide a valid CBM.");
                }
                if (pCartonInfoBo.LengthUomID <= 0)
                {
                    throw new UserException("Please provide a valid LengthUomID.");
                }
                if (pCartonInfoBo.WidthUomID <= 0)
                {
                    throw new UserException("Please provide a valid WidthUomID.");
                }
                if (pCartonInfoBo.HeightUomID <= 0)
                {
                    throw new UserException("Please provide a valid HeightUomID.");
                }
                if (pCartonInfoBo.WeightUomID <= 0)
                {
                    throw new UserException("Please provide a valid WeightUomID.");
                }
                if (pCartonInfoBo.CBMUomID <= 0)
                {
                    throw new UserException("Please provide a valid CBMUomID.");
                }
                if (pCartonInfoBo.Priority <= 0)
                {
                    throw new UserException("Please provide a valid Priority.");
                }
                if (pCartonInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                // validate

                var retCarton = EntitiesContext.CartonInfoes.Where(x => x.ID == pCartonInfoBo.ID).FirstOrDefault();
                if (retCarton != null)
                {
                    retCarton.CartonCode = pCartonInfoBo.CartonCode;
                    retCarton.CartonName = pCartonInfoBo.CartonName;
                    retCarton.Length = pCartonInfoBo.Length;
                    retCarton.Width = pCartonInfoBo.Width;
                    retCarton.Height = pCartonInfoBo.Height;
                    retCarton.Weight = pCartonInfoBo.Weight;
                    retCarton.CBM = pCartonInfoBo.CBM;
                    retCarton.LengthUomID = pCartonInfoBo.LengthUomID;
                    retCarton.WidthUomID = pCartonInfoBo.WidthUomID;
                    retCarton.HeightUomID = pCartonInfoBo.HeightUomID;
                    retCarton.WeightUomID = pCartonInfoBo.WeightUomID;
                    retCarton.CBMUomID = pCartonInfoBo.CBMUomID;
                    retCarton.Priority = pCartonInfoBo.Priority;
                    retCarton.Description = pCartonInfoBo.Description;
                    retCarton.IsActive = pCartonInfoBo.IsActive;
                    retCarton.UpdatedBy = pCartonInfoBo.UpdatedBy;
                    retCarton.UpdatedAt = DateTime.Now;
                    retCarton.UpdatedCount = retCarton.UpdatedCount + 1;

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
        /// Get Carton Info against given Carton Id.
        /// </summary>
        /// <param name="pCartonId"></param>
        /// <returns></returns>
        public CatalogDto GetCartonById(int pCartonId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pCartonId <= 0)
                {
                    throw new UserException("Please provide a valid Carton Id.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var Carton = EntitiesContext.CartonInfoes.Where(x => x.ID == pCartonId).FirstOrDefault();
                if (Carton != null)
                {
                    res.CartonInfoBo = new CartonInfoBo();
                    res.CartonInfoBo.ID = Carton.ID;
                    res.CartonInfoBo.CartonCode = Carton.CartonCode;
                    res.CartonInfoBo.CartonName = Carton.CartonName;
                    res.CartonInfoBo.Length = Carton.Length;
                    res.CartonInfoBo.Width = Carton.Width;
                    res.CartonInfoBo.Height = Carton.Height;
                    res.CartonInfoBo.Weight = Carton.Weight;
                    res.CartonInfoBo.CBM = Carton.CBM;
                    res.CartonInfoBo.LengthUomID = Carton.LengthUomID;
                    res.CartonInfoBo.WidthUomID = Carton.WidthUomID;
                    res.CartonInfoBo.HeightUomID = Carton.HeightUomID;
                    res.CartonInfoBo.WeightUomID = Carton.WeightUomID;
                    res.CartonInfoBo.CBMUomID = Carton.CBMUomID;
                    res.CartonInfoBo.Priority = Carton.Priority;
                    res.CartonInfoBo.Description = Carton.Description;
                    res.CartonInfoBo.IsActive = Carton.IsActive;
                    res.CartonInfoBo.CreatedBy = Carton.CreatedBy;
                    res.CartonInfoBo.CreatedAt = Carton.CreatedAt;
                    res.CartonInfoBo.UpdatedBy = Carton.UpdatedBy;
                    res.CartonInfoBo.UpdatedAt = Carton.UpdatedAt;
                    res.CartonInfoBo.UpdatedCount = Carton.UpdatedCount;
                    res.CartonInfoBo.Notes = Carton.Notes;

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
        /// Get Carton Info against given Carton Code.
        /// </summary>
        /// <param name="pCartonCode"></param>
        /// <returns></returns>
        public CatalogDto GetCartonByCode(string pCartonCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pCartonCode == null)
                {
                    throw new UserException("Please provide a valid Carton Code.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var Carton = EntitiesContext.CartonInfoes.Where(x => x.CartonCode == pCartonCode).FirstOrDefault();
                if (Carton != null)
                {
                    res.CartonInfoBo = new CartonInfoBo();
                    res.CartonInfoBo.ID = Carton.ID;
                    res.CartonInfoBo.CartonCode = Carton.CartonCode;
                    res.CartonInfoBo.CartonName = Carton.CartonName;
                    res.CartonInfoBo.Length = Carton.Length;
                    res.CartonInfoBo.Width = Carton.Width;
                    res.CartonInfoBo.Height = Carton.Height;
                    res.CartonInfoBo.Weight = Carton.Weight;
                    res.CartonInfoBo.CBM = Carton.CBM;
                    res.CartonInfoBo.LengthUomID = Carton.LengthUomID;
                    res.CartonInfoBo.WidthUomID = Carton.WidthUomID;
                    res.CartonInfoBo.HeightUomID = Carton.HeightUomID;
                    res.CartonInfoBo.WeightUomID = Carton.WeightUomID;
                    res.CartonInfoBo.CBMUomID = Carton.CBMUomID;
                    res.CartonInfoBo.Priority = Carton.Priority;
                    res.CartonInfoBo.Description = Carton.Description;
                    res.CartonInfoBo.IsActive = Carton.IsActive;
                    res.CartonInfoBo.CreatedBy = Carton.CreatedBy;
                    res.CartonInfoBo.CreatedAt = Carton.CreatedAt;
                    res.CartonInfoBo.UpdatedBy = Carton.UpdatedBy;
                    res.CartonInfoBo.UpdatedAt = Carton.UpdatedAt;
                    res.CartonInfoBo.UpdatedCount = Carton.UpdatedCount;
                    res.CartonInfoBo.Notes = Carton.Notes;


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
        /// To Get all Cartons then pass parameter value as 'null'. 
        /// To Get all active Cartons then pass parameter value as 'true'. 
        /// To Get all In-active Cartons then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllCartons(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<CartonInfo> CartonList;
                if (pIsActive.HasValue)
                    CartonList = EntitiesContext.CartonInfoes.Where(x => x.IsActive == pIsActive).ToList();
                else
                    CartonList = EntitiesContext.CartonInfoes.ToList();

                if (CartonList != null && CartonList.Count > 0)
                {
                    res.CartonInfoCollection = new List<CartonInfoBo>();
                    foreach (var Carton in CartonList)
                    {
                        CartonInfoBo CartonInfoBo = new CartonInfoBo();
                        CartonInfoBo.ID = Carton.ID;
                        CartonInfoBo.CartonCode = Carton.CartonCode;
                        CartonInfoBo.CartonName = Carton.CartonName;
                        CartonInfoBo.Length = Carton.Length;
                        CartonInfoBo.Width = Carton.Width;
                        CartonInfoBo.Height = Carton.Height;
                        CartonInfoBo.Weight = Carton.Weight;
                        CartonInfoBo.CBM = Carton.CBM;
                        CartonInfoBo.LengthUomID = Carton.LengthUomID;
                        CartonInfoBo.WidthUomID = Carton.WidthUomID;
                        CartonInfoBo.HeightUomID = Carton.HeightUomID;
                        CartonInfoBo.WeightUomID = Carton.WeightUomID;
                        CartonInfoBo.CBMUomID = Carton.CBMUomID;
                        CartonInfoBo.Priority = Carton.Priority;
                        CartonInfoBo.Description = Carton.Description;
                        CartonInfoBo.IsActive = Carton.IsActive;
                        CartonInfoBo.CreatedBy = Carton.CreatedBy;
                        CartonInfoBo.CreatedAt = Carton.CreatedAt;
                        CartonInfoBo.UpdatedBy = Carton.UpdatedBy;
                        CartonInfoBo.UpdatedAt = Carton.UpdatedAt;
                        CartonInfoBo.UpdatedCount = Carton.UpdatedCount;
                        CartonInfoBo.Notes = Carton.Notes;
                        res.CartonInfoCollection.Add(CartonInfoBo);

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
