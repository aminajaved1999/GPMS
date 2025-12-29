using BLL.GPMS;
using Entities.GPMS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest.GPMS
{
    [TestClass]
    public class PackingUnitTest
    {
        [TestMethod]
        public void Test_IsPackingPlanAlreadyProcessed()
        {
            string pFileName = "testfilename";

            var packingPlanDataManager = new PackingPlanDataManager();

            var result = packingPlanDataManager.IsPackingPlanAlreadyProcessed(pFileName);

            //Assert.IsFalse(result.Value);
            Assert.IsTrue(result.IsExist.Value);
        }

        [TestMethod]
        public void Test_AddPackingPlanData()
        {
            var packingManager = new PackingPlanDataManager();
            var packingPlanDataBo1 = new PackingPlanDataBo
            {
                CustomerID = 1,
                SourceFileName = "source_file_1.txt",
                CreatedByID = 123,
            };
            var packingPlanDataBo2 = new PackingPlanDataBo
            {
                CustomerID = 2,
                SourceFileName = "source_file_2.txt",
                CreatedByID = 456,
            };

            var packingDto = new PackingDto
            {
                PackingPlanDataList = new List<PackingPlanDataBo> { packingPlanDataBo1, packingPlanDataBo2 }
            };

            var result = packingManager.AddPackingPlanData(packingDto);

            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
        }

        [TestMethod]
        public void Test_GetLabels_AcdSprt()
        {
            var packingManager = new PackingPlanDataManager();
            int customerID = 1;
            string poNo = "PO234";
            DateTime createdDate = new DateTime(2024, 04, 26);

            var result = packingManager.GetLabels_AcdSprt(customerID, poNo, createdDate);

            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);

            Assert.IsNotNull(result.DataTable);
            Assert.AreEqual(11, result.DataTable.Columns.Count);
            Assert.IsTrue(result.DataTable.Rows.Count > 0); 

        }

        [TestMethod]
        public void Test_GetPackQty()
        {
            var packingManager = new PackingPlanDataManager();
            int customerID = 1;
            string poNo = "PO234";
            DateTime createdDate = new DateTime(2024, 04, 26);

            var result = packingManager.GetPackQty(customerID, poNo, createdDate);

            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);

            Assert.IsNotNull(result.DataTable);
            Assert.AreEqual(9, result.DataTable.Columns.Count); 
            Assert.IsTrue(result.DataTable.Rows.Count > 0);
        }

        [TestMethod]
        public void GetBoxDataByBarcode()
        {
            var PackingInstructionMManager = new PackingInstructionMManager();

            string pBoxBacode = "00000000000000000017";

            var result = PackingInstructionMManager.GetBoxDataByBarcode(pBoxBacode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.PackingInstructionMBo);
            Assert.IsNotNull(result.PackingInstructionMBo.CustomerInfoBo);
            Assert.IsNotNull(result.PackingInstructionMBo.PackingInstructionDList);
            Assert.IsTrue(result.PackingInstructionMBo.PackingInstructionDList.Count > 0);

            //Assert.IsNotNull(result.PackingInstructionDBo.StyleInfoBo);
            //Assert.IsNotNull(result.PackingInstructionDBo.ColorInfoBo);
            //Assert.IsNotNull(result.PackingInstructionDBo.SizeInfoBo);
            //


        }

        [TestMethod]
        public void SaveBoxPacking()
        {
            var PackingInstructionMManager = new PackingInstructionMManager();
            int pPackingInstructionMID = 1;
            int pUpdatedByID = 1;
            string pUpdatedBy = "John";

            var result = PackingInstructionMManager.SaveBoxPacking(pPackingInstructionMID, pUpdatedByID, pUpdatedBy);

            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
        }
    }
}
