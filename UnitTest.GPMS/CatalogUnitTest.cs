using BLL.GPMS;
using Entities.GPMS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest.GPMS
{
    [TestClass]
    public class CatalogUnitTest
    {
        #region Valid Carton Tests
        [TestMethod]
        public void Test_AddCarton()
        {
            var cartonInfoManager = new CartonInfoManager();
            var cartonInfoBo = new CartonInfoBo
            {
                CustomerID = 1,
                CartonCode = "CtnCode4",
                CartonName = "CartonName4",
                Length = 10,
                Width = 5,
                Height = 8,
                Weight = 15,
                CBM = 100,
                LengthUomID = 1,
                WidthUomID = 2,
                HeightUomID = 3,
                WeightUomID = 4,
                CBMUomID = 5,
                Priority = 1,
                IsActive = true,
                CreatedBy = "Amina"
            };

            var result = cartonInfoManager.AddCarton(cartonInfoBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.CartonInfoBo.ID > 0);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.CartonInfoBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("Carton code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdateCarton()
        {
            var CartonInfoManager = new CartonInfoManager();
            var CartonInfoBo = new CartonInfoBo
            {
                ID = 1,
                CustomerID = 1,
                CartonCode = "CtnCode1",
                CartonName = "CartonName1",
                Length = 09,
                Width = 5,
                Height = 8,
                Weight = 15,
                CBM = 100,
                LengthUomID = 1,
                WidthUomID = 2,
                HeightUomID = 3,
                WeightUomID = 4,
                CBMUomID = 5,
                Priority = 1,
                IsActive = true,
                UpdatedBy = "Amina"
            };


            var result = CartonInfoManager.UpdateCarton(CartonInfoBo);
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
        public void Test_GetCartonById()
        {
            int validCartonId = 1;
            var CartonInfoManager = new CartonInfoManager();

            var result = CartonInfoManager.GetCartonById(validCartonId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.CartonInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.CartonInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetCartonByCode()
        {
            string validCartonCode = "CtnCode1";
            var CartonInfoManager = new CartonInfoManager();

            var result = CartonInfoManager.GetCartonByCode(validCartonCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.CartonInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.CartonInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllCartons()
        {
            var CartonInfoManager = new CartonInfoManager();

            var result = CartonInfoManager.GetAllCartons(true);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.CartonInfoCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.CartonInfoCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid Carton Tests

        #region Valid Color Tests
        [TestMethod]
        public void Test_AddColor()
        {
            var ColorInfoManager = new ColorInfoManager();
            var ColorInfoBo = new ColorInfoBo
            {
                CustomerID = 1,
                ColorCode = "TestColorCode2",
                ColorName = "TestColorName2",
                IsActive = true,
                CreatedBy = "Amina"
            };

            var result = ColorInfoManager.AddColor(ColorInfoBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.ColorInfoBo.ID > 0);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.ColorInfoBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("Color code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdateColor()
        {
            var ColorInfoManager = new ColorInfoManager();
            var ColorInfoBo = new ColorInfoBo
            {
                ID = 5,
                CustomerID = 1,
                ColorCode = "TestColorCode1",
                ColorName = "TestColorName1",
                IsActive = true,
                UpdatedBy = "Amina"
            };


            var result = ColorInfoManager.UpdateColor(ColorInfoBo);
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
        public void Test_GetColorById()
        {
            int validColorId = 1;
            var ColorInfoManager = new ColorInfoManager();

            var result = ColorInfoManager.GetColorById(validColorId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.ColorInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.ColorInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetColorByCode()
        {
            string validColorCode = "1";
            var ColorInfoManager = new ColorInfoManager();

            var result = ColorInfoManager.GetColorByCode(validColorCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.ColorInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.ColorInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllColors()
        {
            var ColorInfoManager = new ColorInfoManager();

            var result = ColorInfoManager.GetAllColors(true);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.ColorInfoCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.ColorInfoCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid Color Tests

        #region Valid Customer Tests
        [TestMethod]
        public void Test_AddCustomer()
        {
            var CustomerInfoManager = new CustomerInfoManager();
            var customerInfoBo = new CustomerInfoBo
            {
                CompanyID = 1,
                CustomerCode = "TestCode5",
                CustomerName = "TestName5",
                IsActive = true,
            };

            var result = CustomerInfoManager.AddCustomer(customerInfoBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.CustomerInfoBo.ID > 0);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.CustomerInfoBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("Customer code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdateCustomer()
        {
            var customerInfoManager = new CustomerInfoManager();
            var customerInfoBo = new CustomerInfoBo
            {
                ID = 1,
                CompanyID = 1,
                CustomerCode = "1",
                CustomerName = "Test",
                IsActive = true,
            };

            var result = customerInfoManager.UpdateCustomer(customerInfoBo);
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
        public void Test_GetCustomerById()
        {
            int validCustomerId = 1;
            var CustomerInfoManager = new CustomerInfoManager();

            var result = CustomerInfoManager.GetCustomerById(validCustomerId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.CustomerInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.CustomerInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetCustomerByCode()
        {
            string validCustomerCode = "TestCode2";
            var CustomerInfoManager = new CustomerInfoManager();

            var result = CustomerInfoManager.GetCustomerByCode(validCustomerCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.CustomerInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.CustomerInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllCustomers()
        {
            var CustomerInfoManager = new CustomerInfoManager();

            var result = CustomerInfoManager.GetAllCustomers(false);

            ////success
            //Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            //Assert.IsTrue(result.CustomerInfoCollection.Count >0);
            ////

            //no data found
            Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            Assert.IsTrue(result.CustomerInfoCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid Customer Tests

        #region Valid PackingType Tests

        [TestMethod]
        public void Test_GetPackingTypeById()
        {
            int validPackingTypeId = 1;
            var PackingTypeManager = new PackingTypeManager();

            var result = PackingTypeManager.GetPackingTypeById(validPackingTypeId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.PackingTypeBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.PackingTypeBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetPackingTypeByCode()
        {
            string validPackingTypeCode = "S01";
            var PackingTypeManager = new PackingTypeManager();

            var result = PackingTypeManager.GetPackingTypeByCode(validPackingTypeCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.PackingTypeBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.PackingTypeBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllPackingTypes()
        {
            var PackingTypeManager = new PackingTypeManager();

            var result = PackingTypeManager.GetAllPackingTypes(true);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.PackingTypeCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.PackingTypeCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid PackingType Tests

        #region Valid PaymentMode Tests
        [TestMethod]
        public void Test_AddPaymentMode()
        {
            var PaymentModeManager = new PaymentModeManager();
            var PaymentModeBo = new PaymentModeInfoBo
            {
                PaymentModeCode = "PMCode1",
                PaymentModeName = "TestPaymentModeName1",
                IsActive = true,
                CreatedBy = "Amina"
            };

            var result = PaymentModeManager.AddPaymentMode(PaymentModeBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.PaymentModeInfoBo.ID > 0);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.PaymentModeBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("PaymentMode code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdatePaymentMode()
        {
            var PaymentModeManager = new PaymentModeManager();
            var PaymentModeBo = new PaymentModeInfoBo
            {
                ID = 7,
                PaymentModeCode = "uptPMCode1",
                PaymentModeName = "TestPaymentModeName1",
                IsActive = true,
                UpdatedBy = "Amina"
            };


            var result = PaymentModeManager.UpdatePaymentMode(PaymentModeBo);
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
        public void Test_GetPaymentModeById()
        {
            int validPaymentModeId = 1;
            var PaymentModeManager = new PaymentModeManager();

            var result = PaymentModeManager.GetPaymentModeById(validPaymentModeId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.PaymentModeInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.PaymentModeBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetPaymentModeByCode()
        {
            string validPaymentModeCode = "P01";
            var PaymentModeManager = new PaymentModeManager();

            var result = PaymentModeManager.GetPaymentModeByCode(validPaymentModeCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.PaymentModeInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.PaymentModeBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllPaymentModes()
        {
            var PaymentModeManager = new PaymentModeManager();

            var result = PaymentModeManager.GetAllPaymentModes(null);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.PaymentModeInfoCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.PaymentModeCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid PaymentMode Tests

        #region Valid POForm Tests

        [TestMethod]
        public void Test_GetPOFormById()
        {
            int validPOFormId = 1;
            var POFormManager = new POFormManager();

            var result = POFormManager.GetPOFormById(validPOFormId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POFormBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POFormBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetPOFormByCode()
        {
            string validPOFormCode = "F01";
            var POFormManager = new POFormManager();

            var result = POFormManager.GetPOFormByCode(validPOFormCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POFormBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POFormBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllPOForms()
        {
            var POFormManager = new POFormManager();

            var result = POFormManager.GetAllPOForms(true);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.POFormCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POFormCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid POForm Tests

        #region Valid POLevel Tests

        [TestMethod]
        public void Test_GetPOLevelById()
        {
            int validPOLevelId = 1;
            var POLevelManager = new POLevelManager();

            var result = POLevelManager.GetPOLevelById(validPOLevelId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POLevelBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POLevelBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetPOLevelByCode()
        {
            string validPOLevelCode = "L01";
            var POLevelManager = new POLevelManager();

            var result = POLevelManager.GetPOLevelByCode(validPOLevelCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POLevelBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POLevelBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllPOLevels()
        {
            var POLevelManager = new POLevelManager();

            var result = POLevelManager.GetAllPOLevels(true);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.POLevelCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POLevelCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid POLevel Tests

        #region Valid POType Tests

        [TestMethod]
        public void Test_GetPOTypeById()
        {
            int validPOTypeId = 1;
            var POTypeManager = new POTypeManager();

            var result = POTypeManager.GetPOTypeById(validPOTypeId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POTypeBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POTypeBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetPOTypeByCode()
        {
            string validPOTypeCode = "T01";
            var POTypeManager = new POTypeManager();

            var result = POTypeManager.GetPOTypeByCode(validPOTypeCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.POTypeBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POTypeBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllPOTypes()
        {
            var POTypeManager = new POTypeManager();

            var result = POTypeManager.GetAllPOTypes(true);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.POTypeCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.POTypeCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid POType Tests

        #region Valid ShipmentTerm Tests

        [TestMethod]
        public void Test_GetShipmentTermById()
        {
            int validShipmentTermId = 1;
            var ShipmentTermManager = new ShipmentTermManager();

            var result = ShipmentTermManager.GetShipmentTermById(validShipmentTermId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.ShipmentTermBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.ShipmentTermBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetShipmentTermByCode()
        {
            string validShipmentTermCode = "S01";
            var ShipmentTermManager = new ShipmentTermManager();

            var result = ShipmentTermManager.GetShipmentTermByCode(validShipmentTermCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.ShipmentTermBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.ShipmentTermBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllShipmentTerms()
        {
            var ShipmentTermManager = new ShipmentTermManager();

            var result = ShipmentTermManager.GetAllShipmentTerms(true);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.ShipmentTermCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.ShipmentTermCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid ShipmentTerm Tests

        #region Valid Size Tests
        [TestMethod]
        public void Test_AddSize()
        {
            var SizeInfoManager = new SizeInfoManager();
            var SizeInfoBo = new SizeInfoBo
            {
                SizeCode = "SizeCode2",
                SizeName = "SizeName2",
                IsActive = true,
                CreatedBy = "Amina",
            };

            var result = SizeInfoManager.AddSize(SizeInfoBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.SizeInfoBo.ID > 0);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.SizeInfoBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("Size code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdateSize()
        {
            var SizeInfoManager = new SizeInfoManager();
            var SizeInfoBo = new SizeInfoBo
            {
                ID = 7,
                SizeCode = "SizeCode1",
                SizeName = "SizeName1",
                IsActive = true,
                UpdatedBy = "Amina"
            };


            var result = SizeInfoManager.UpdateSize(SizeInfoBo);
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
        public void Test_GetSizeById()
        {
            int validSizeId = 1;
            var SizeInfoManager = new SizeInfoManager();

            var result = SizeInfoManager.GetSizeById(validSizeId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.SizeInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.SizeInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetSizeByCode()
        {
            string validSizeCode = "SizeCode1";
            var SizeInfoManager = new SizeInfoManager();

            var result = SizeInfoManager.GetSizeByCode(validSizeCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.SizeInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.SizeInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllSizes()
        {
            var SizeInfoManager = new SizeInfoManager();
            var result = SizeInfoManager.GetAllSizes(null);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.SizeInfoCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.SizeInfoCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid Size Tests

        #region Valid Style Tests
        [TestMethod]
        public void Test_AddStyle()
        {
            var StyleInfoManager = new StyleInfoManager();
            var StyleInfoBo = new StyleInfoBo
            {
                CustomerID = 1,
                StyleCode = "StyleCode",
                StyleName = "StyleName",
                IsActive = true,
                CreatedBy = "Amina"
            };

            var result = StyleInfoManager.AddStyle(StyleInfoBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.StyleInfoBo.ID > 0);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.StyleInfoBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("Style code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdateStyle()
        {
            var StyleInfoManager = new StyleInfoManager();
            var StyleInfoBo = new StyleInfoBo
            {
                ID = 7,
                CustomerID = 1,
                StyleCode = "StyleCode1",
                StyleName = "StyleName1",
                IsActive = true,
                UpdatedBy = "Amina"
            };


            var result = StyleInfoManager.UpdateStyle(StyleInfoBo);
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
        public void Test_GetStyleById()
        {
            int validStyleId = 1;
            var StyleInfoManager = new StyleInfoManager();

            var result = StyleInfoManager.GetStyleById(validStyleId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.StyleInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.StyleInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetStyleByCode()
        {
            string validStyleCode = "StyleCode1";
            var StyleInfoManager = new StyleInfoManager();

            var result = StyleInfoManager.GetStyleByCode(validStyleCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.StyleInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.StyleInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllStyles()
        {
            var StyleInfoManager = new StyleInfoManager();

            var result = StyleInfoManager.GetAllStyles(true);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.StyleInfoCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.StyleInfoCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid Style Tests

        #region Valid Term Tests
        [TestMethod]
        public void Test_AddTerm()
        {
            var TermInfoManager = new TermInfoManager();
            var TermInfoBo = new TermInfoBo
            {
                TermCode = "TermCode",
                TermName = "TermName",
                IsActive = true,
                CreatedBy = "Amina"
            };

            var result = TermInfoManager.AddTerm(TermInfoBo);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.TermInfoBo.ID > 0);
            //

            ////failed - Missing required fields
            //Assert.AreEqual(DtoStatus.RecordNotAdded, result.DtoStatus);
            //Assert.IsNull(result.TermInfoBo);
            ////

            ////failed - Duplicate code
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsTrue(result.DtoStatusNotes.Exception.Contains("Term code already exist"));
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_UpdateTerm()
        {
            var TermInfoManager = new TermInfoManager();
            var TermInfoBo = new TermInfoBo
            {
                ID = 2,
                TermCode = "TermCode1",
                TermName = "TermName1",
                IsActive = true,
                UpdatedBy = "Amina"
            };


            var result = TermInfoManager.UpdateTerm(TermInfoBo);
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
        public void Test_GetTermById()
        {
            int validTermId = 1;
            var TermInfoManager = new TermInfoManager();

            var result = TermInfoManager.GetTermById(validTermId);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.TermInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.TermInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);

        }

        [TestMethod]
        public void Test_GetTermByCode()
        {
            string validTermCode = "TermCode1";
            var TermInfoManager = new TermInfoManager();

            var result = TermInfoManager.GetTermByCode(validTermCode);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsNotNull(result.TermInfoBo);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.TermInfoBo == null);
            ////

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }

        [TestMethod]
        public void Test_GetAllTerms()
        {
            var TermInfoManager = new TermInfoManager();

            var result = TermInfoManager.GetAllTerms(true);

            //success
            Assert.AreEqual(DtoStatus.Success, result.DtoStatus);
            Assert.IsTrue(result.TermInfoCollection.Count > 0);
            //

            ////no data found
            //Assert.AreEqual(DtoStatus.NoDataFound, result.DtoStatus);
            //Assert.IsTrue(result.TermInfoCollection == null);
            //

            ////other expetions
            //Assert.AreEqual(DtoStatus.Error, result.DtoStatus);
            //Assert.IsNotNull(result.DtoStatusNotes.Exception);
        }
        #endregion Valid Term Tests
    }
}
