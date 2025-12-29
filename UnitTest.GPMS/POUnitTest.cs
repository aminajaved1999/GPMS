using ASL.GPMS;
using BLL.GPMS;
using Entities.GPMS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest.GPMS
{
    [TestClass]
    public class POUnitTest
    {

        #region Valid POM Tests
        [TestMethod]
        public void Test_AddPOM()
        {
            var POManager = new POManager();
            var POMBo = new POMBo
            {
                CustomerID = 1,
                PONo = "PONo",
                POReceivedDate = DateTime.Now,
                PaymentModeID = 1,
                TermID = 1,
                ShippingMethodID = 1,
                ShipmentTermID = 1,
                POFromID = 1,
                POTypeID = 1,
                POLevelID = 1,
                PackingTypeID = 1,
                POStatus = "N",
                CreatedBy = "Amina"
            };

            var result = POManager.AddPOM(POMBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.POMBo.ID > 0);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.POMBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("POM code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdatePOM()
        {
            var POManager = new POManager();
            var POMBo = new POMBo
            {
                ID = 12,
                CustomerID = 1,
                PONo = "TestPONo",
                POReceivedDate = DateTime.Now,
                PaymentModeID = 1,
                TermID = 1,
                ShippingMethodID = 1,
                ShipmentTermID = 1,
                POFromID = 1,
                POTypeID = 1,
                POLevelID = 1,
                PackingTypeID = 1,
                POStatus = "N",
                UpdatedBy = "Amina"
            };


            var result = POManager.UpdatePOM(POMBo);
            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);


            ////failed
            //Assert.AreEqual(DtoStatus.RecordNotUpdatedWithoutChanges, result.DtoStatus);
            ////
            ////failed
            //Assert.AreEqual(DtoStatus.RecordNotUpdated, result.DtoStatus);
            ////
            ////failed
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);

            ////other expetions
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetPOMById()
        {
            int validPOMId = 1;
            var POManager = new POManager();

            var result = POManager.GetPOMById(validPOMId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POMBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POMBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetPOByPONo()
        {
            var orderManager = new POManager();
            string validPONo = "PONo";

            var result = orderManager.GetPOByPONo(validPONo);

            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POMBo);
        }

        [TestMethod]
        public void Test_DeletePOM()
        {
            var POMManager = new POManager();
            var POMIdToDelete = 15;
            int userId = 1;

            var result = POMManager.DeletePOM(POMIdToDelete, userId);

            // Success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);

            //// Failed - RecordNotDeleted
            //Assert.AreEqual(DtoStatus.RecordNotDeleted, result.DtoStatus);
            //
            //// Failed - NoDataFound
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //
            //// Other exceptions
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void UpdatePOApprovedStatus()
        {
            var POManager = new POManager();
            var POApprovalStatusBo = new POApprovalStatusBo
            {
                POMID = 2,
                Status = "A",
                StatusBy = "Amina"
            };

            var result = POManager.UpdatePOApprovedStatus(POApprovalStatusBo);

            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
        }

        [TestMethod]
        public void Test_IsPONumberExist()
        {
            string PONo = "TestPONo";

            var poManager = new POManager();

            var result = poManager.IsPONumberExist(PONo);

            Assert.IsTrue(result.IsExist.Value);
        }

        #endregion Valid POM Tests

        #region Valid POD Tests
        [TestMethod]
        public void Test_AddPOD()
        {
            var POManager = new POManager();
            var PODBo1 = new PODBo
            {
                POMID = 1,
                StyleID = 1,
                CreatedBy = "Amina"
            };
            var PODBo2 = new PODBo
            {
                POMID = 2,
                StyleID = 2,
                CreatedBy = "Amina"
            };

            var result = POManager.AddPOD(new List<PODBo> { PODBo1, PODBo2 });

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.PODBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("POD code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdatePOD()
        {
            var POManager = new POManager();
            var PODBo = new PODBo
            {
                ID = 18,
                POMID = 12,
                StyleID = 2,
                UpdatedBy = "Amina"
            };
            var result = POManager.UpdatePOD(PODBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);


            ////failed
            //Assert.AreEqual(DtoStatus.RecordNotUpdatedWithoutChanges, result.DtoStatus);
            ////
            ////failed
            //Assert.AreEqual(DtoStatus.RecordNotUpdated, result.DtoStatus);
            ////
            ////failed
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);

            ////other expetions
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_AddUpdatePOD()
        {
            var POManager = new POManager();
            var PODBo1 = new PODBo
            {
                ID = 17,
                POMID = 1,
                StyleID = 2,
                CreatedBy = "Amina",
                UpdatedBy = "Amina"
            };
            var PODBo2 = new PODBo
            {
                POMID = 2,
                StyleID = 2,
                CreatedBy = "Amina",
                UpdatedBy = "Amina"
            };

            var result = POManager.AddUpdatePOD(new List<PODBo> { PODBo1, PODBo2 });

            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
        }

        [TestMethod]
        public void Test_GetPODById()
        {
            int validPODId = 11;
            var POManager = new POManager();

            var result = POManager.GetPODById(validPODId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.PODBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.PODBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_DeletePOD()
        {
            var PODManager = new POManager();
            var PODIdToDelete = 20;
            int userId = 1;
            var result = PODManager.DeletePOD(PODIdToDelete, userId);

            // Success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);

            //// Failed - RecordNotDeleted
            //Assert.AreEqual(DtoStatus.RecordNotDeleted, result.DtoStatus);
            //
            //// Failed - NoDataFound
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //
            //// Other exceptions
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        #endregion Valid POD Tests

        #region Valid POSizeD Tests
        [TestMethod]
        public void Test_AddPOSizeD()
        {
            var POManager = new POManager();
            var POSizeDBo1 = new POSizeDBo
            {
                PODID = 1,
                ColorID = 1,
                SizeID = 1,
                Price = 1,
                CreatedBy = "Amina"
            };
            var POSizeDBo2 = new POSizeDBo
            {
                PODID = 2,
                ColorID = 2,
                SizeID = 1,
                Price = 1,
                CreatedBy = "Amina"
            };

            var result = POManager.AddPOSizeD(new List<POSizeDBo> { POSizeDBo1, POSizeDBo2 });

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.POSizeDBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("POSizeD code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdatePOSizeD()
        {
            var POManager = new POManager();
            var POSizeDBo = new POSizeDBo
            {
                ID = 9,
                PODID = 18,
                ColorID = 1,
                SizeID = 2,
                Price = 1,
                UpdatedBy = "Amina"
            };
            var result = POManager.UpdatePOSizeD(POSizeDBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);


            ////failed
            //Assert.AreEqual(DtoStatus.RecordNotUpdatedWithoutChanges, result.DtoStatus);
            ////
            ////failed
            //Assert.AreEqual(DtoStatus.RecordNotUpdated, result.DtoStatus);
            ////
            ////failed
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);

            ////other expetions
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetPOSizeDById()
        {
            int validPOSizeDId = 1;
            var POManager = new POManager();

            var result = POManager.GetPOSizeDById(validPOSizeDId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POSizeDBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POSizeDBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_AddUpdatePOSizeD()
        {
            var POManager = new POManager();
            var POSizeDBo1 = new POSizeDBo
            {
                ID = 8,
                PODID = 3,
                ColorID = 3,
                SizeID = 3,
                Price = 3,
                CreatedBy = "Amina",
                UpdatedBy = "Amina"
            };
            var POSizeDBo2 = new POSizeDBo
            {
                PODID = 1,
                ColorID = 1,
                SizeID = 1,
                Price = 1,
                CreatedBy = "Amina",
                UpdatedBy = "Amina"
            };

            var result = POManager.AddUpdatePOSizeD(new List<POSizeDBo> { POSizeDBo1, POSizeDBo2 });

            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
        }

        [TestMethod]
        public void Test_DeletePOSizeD()
        {
            var POSizeDManager = new POManager();
            var POSizeDIdToDelete = 15;
            int userId = 1;
            var result = POSizeDManager.DeletePOSizeD(POSizeDIdToDelete, userId);

            // Success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);

            //// Failed - RecordNotDeleted
            //Assert.AreEqual(DtoStatus.RecordNotDeleted, result.DtoStatus);
            //
            //// Failed - NoDataFound
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //
            //// Other exceptions
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_DeletePOSizeDCollection()
        {
            var POSizeDManager = new POManager();
            var POSizeDIdsToDelete = new List<int> { 13, 14, 15 };
            int userId = 1;

            var result = POSizeDManager.DeletePOSizeDCollection(POSizeDIdsToDelete, userId);

            // Success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);

            //// Failed - RecordNotDeleted
            //Assert.AreEqual(DtoStatus.RecordNotDeleted, result.DtoStatus);
            //
            //// Failed - NoDataFound
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //
            //// Other exceptions
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_IsItemExistInPO()
        {
            string PONo = "TestPONo";
            string ItemNo = "TESTITEMNO";

            var poManager = new POManager();

            var result = poManager.IsItemExistInPO(PONo, ItemNo);

            Assert.IsTrue(result.IsExist.Value);
        }

        [TestMethod]
        public void Test_IsPackQtyValid()
        {
            int pCustomerID = 1;
            string PONo = "TestPONo";
            string ItemNo = "TESTITEMNO";
            int CurrentPackQty = 5;

            var poManager = new POManager();

            var result = poManager.IsPackQtyValid(pCustomerID, PONo, ItemNo, CurrentPackQty);

            Assert.IsTrue(result.IsExist.Value);
        }

        [TestMethod]
        public void Test_GetItemNo()
        {
            var POManager = new POManager();
            int customerID = 1;
            int styleID = 2;
            int colorID = 1;
            int sizeID = 2;

            var result = POManager.GetItemNo(customerID, styleID, colorID, sizeID);

            // Success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POSizeDBo.ItemNo);

            //// Failed - More than one distinct ItemNo found
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
            //Assert.AreEqual("More than one distinct ItemNo found.", result.DtoStatusNotes.Exception);

            //// Failed - No distinct ItemNo found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
            //Assert.AreEqual("No distinct ItemNo found.", result.DtoStatusNotes.Exception);

            //// Other exceptions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        #endregion Valid POSizeD Tests


    }
}
