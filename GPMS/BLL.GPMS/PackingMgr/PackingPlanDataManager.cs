using Entities.GPMS;
using MODEL.GPMS;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GPMS.PackingMgr
{
    class PackingPlanDataManager : DbBase
    {
        /// <summary>
        /// Add new Packing Plan Data.
        /// </summary>
        /// <param name="packingPlanDataBo"></param>
        /// <returns></returns>
        public PackingDto AddPackingPlanData(PackingPlanDataBo packingPlanDataBo)
        {
            PackingDto resPackingPlanData = new PackingDto();

            try
            {
                PackingPlanData PackingPlanData = new PackingPlanData();

                // validate
                if (string.IsNullOrEmpty(packingPlanDataBo.SourceFileName))
                    throw new UserException("Source file name connot be null/empty.");
                if (string.IsNullOrEmpty(packingPlanDataBo.SourceFileName))
                    throw new UserException("Source file name connot be null/empty.");
                if (string.IsNullOrEmpty(packingPlanDataBo.SourceFileName))
                    throw new UserException("Source file name connot be null/empty.");
                //

                PackingPlanData.ID = packingPlanDataBo.ID;
                PackingPlanData.CustomerID = packingPlanDataBo.CustomerID;
                PackingPlanData.SourceFileName = packingPlanDataBo.SourceFileName;
                PackingPlanData.PONo = packingPlanDataBo.PONo;
                PackingPlanData.GroupNo = packingPlanDataBo.GroupNo;
                PackingPlanData.GroupCartonQty = packingPlanDataBo.GroupCartonQty;
                PackingPlanData.PCsPerCarton = packingPlanDataBo.PCsPerCarton;
                PackingPlanData.Color = packingPlanDataBo.Color;
                PackingPlanData.Style = packingPlanDataBo.Style;
                PackingPlanData.Size = packingPlanDataBo.Size;
                PackingPlanData.SizePackPCsQty = packingPlanDataBo.SizePackPCsQty;
                PackingPlanData.UPC = packingPlanDataBo.UPC;
                PackingPlanData.StoreNo = packingPlanDataBo.StoreNo;
                PackingPlanData.DC = packingPlanDataBo.DC;
                PackingPlanData.UccPartners = packingPlanDataBo.UccPartners;
                PackingPlanData.UccType = packingPlanDataBo.UccType;
                PackingPlanData.UccCoo = packingPlanDataBo.UccCoo;
                PackingPlanData.Description = packingPlanDataBo.Description;
                PackingPlanData.CreatedBy = packingPlanDataBo.CreatedBy;
                PackingPlanData.CreatedAt = DateTime.Now;
                PackingPlanData.UpdatedBy = packingPlanDataBo.UpdatedBy;
                PackingPlanData.UpdatedAt = packingPlanDataBo.UpdatedAt;
                PackingPlanData.UpdatedCount = packingPlanDataBo.UpdatedCount;
                PackingPlanData.Notes = packingPlanDataBo.Notes;
                PackingPlanData.UpdatedCount = 0;

                EntitiesContext.PackingPlanDatas.Add(PackingPlanData);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    resPackingPlanData.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    resPackingPlanData.DtoStatus = DtoStatus.RecordNotAdded;
                    resPackingPlanData.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                }
            }
            catch (UserException ux)
            {
                resPackingPlanData.DtoStatus = DtoStatus.RecordNotAdded;
                resPackingPlanData.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                resPackingPlanData.DtoStatus = DtoStatus.Error;
                resPackingPlanData.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return resPackingPlanData;
        }

    }
}
