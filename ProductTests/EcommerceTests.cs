namespace eCommerce_application
{
    public class ProductTests
    {
        private eCommerce_application.Product _product { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            _product = new eCommerce_application.Product(1, "AS Product", 10, 50);
        }
        [Test]
        public void ProductId_Test()
        {
            // Assign
            int expectedProductId = 1;

            // Act
            int actualProductId = _product.ProductID;

            // Assert
            Assert.That(actualProductId, Is.EqualTo(expectedProductId));
        }

        [Test]
        public void ProductId_MinimumValue_Test()
        {
            // Assign
            _product = new eCommerce_application.Product(1, "Minimum Product", 10, 50);
            int expectedMinimumProductId = 1;

            // Act
            int actualMinimumProductId = _product.ProductID;

            // Assert
            Assert.That(actualMinimumProductId, Is.EqualTo(expectedMinimumProductId));
        }

        [Test]
        public void ProductId_MaximumValue_Test()
        {
            // Assign
            _product = new eCommerce_application.Product(1000, "Maximum Product", 10, 50);
            int expectedMaximumProductId = 1000;

            // Act
            int actualMaximumProductId = _product.ProductID;

            // Assert
            Assert.That(actualMaximumProductId, Is.EqualTo(expectedMaximumProductId));
        }

        // Unit tests for ProductName 
        [Test]
        public void ProductName_Testt()
        {
            // Assign
            string expectedProductName = "AS Product ";

            // Act
            _product.ProductName = expectedProductName;
            string actualProductName = _product.ProductName;

            // Assert
            Assert.That(actualProductName, Is.EqualTo(expectedProductName));
        }

        [Test]
        public void ProductName_not_null_test()
        {
            // Assign
            string productName = "Not Null";

            // Act
            _product.ProductName = productName;

            // Assert
            Assert.That(_product.ProductName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void ProductName_String_test()
        {
            // Assign
            string productName = "String";

            // Act
            object productNameObj = _product.ProductName;

            // Assert
            Assert.That(productNameObj, Is.InstanceOf<string>());
        }

        // Unit tests for Price 
        [Test]
        public void Correct_Price_test()
        {
            // Assign
            decimal expectedPrice = 15;

            // Act
            _product.Price = expectedPrice;
            decimal actualPrice = _product.Price;

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void Minimum_Price_Test()
        {
            // Assign
            decimal price = 1;

            // Act
            _product.Price = price;
            decimal actualPrice = _product.Price;

            // Assert
            Assert.That(actualPrice, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void Maximum_price_test()
        {
            // Assign
            decimal price = 5000;

            // Act
            _product.Price = price;
            decimal actualPrice = _product.Price;

            // Assert
            Assert.That(actualPrice, Is.LessThanOrEqualTo(5000));
        }

        // Unit tests for Stock 
        [Test]
        public void Correct_Stock_Test()
        {
            // Assign
            int expectedStock = 75;

            // Act
            _product.Stock = expectedStock;
            int actualStock = _product.Stock;

            // Assert
            Assert.That(actualStock, Is.EqualTo(expectedStock));
        }

        [Test]
        public void Minimum_Stock_Test()
        {
            // Assign
            int minimumStock = 1;

            // Act
            _product.Stock = minimumStock;
            int actualMinimumStock = _product.Stock;

            // Assert
            Assert.That(actualMinimumStock, Is.EqualTo(minimumStock));
        }

        [Test]
        public void Stock_MaximumValue_Test()
        {
            // Assign
            int stock = 1000;

            // Act
            _product.Stock = stock;
            int actualStock = _product.Stock;

            // Assert
            Assert.That(actualStock, Is.EqualTo(1000));
        }


        // Unit tests for IncreaseStock method
        [Test]
        public void IncreaseStock_Givennumber()
        {
            // Assign
            int increaseAmount = 30;

            // Act
            int initialStock = _product.Stock;
            _product.IncreaseStock(increaseAmount);
            int actualStockAfterIncrease = _product.Stock;

            // Assert
            Assert.That(actualStockAfterIncrease, Is.EqualTo(initialStock + increaseAmount));
        }

        [Test]
        public void IncreaseStock_notdecrease()
        {
            // Assign
            int initialStock = _product.Stock;

            // Act
            _product.IncreaseStock(20);
            int increasedStock = _product.Stock;

            // Assert
            Assert.That(increasedStock, Is.EqualTo(initialStock + 20));
        }

        [Test]
        public void IncreaseStock_maximum()
        {
            // Assign
            int increaseAmount = 200;

            // Act
            _product.IncreaseStock(increaseAmount);
            int increasedStock = _product.Stock;

            // Assert
            Assert.That(increasedStock, Is.LessThanOrEqualTo(1000));
        }

        // Unit tests for DecreaseStock method
        [Test]
        public void DecreaseStock_Givennumber()
        {
            // Assign
            int decreaseAmount = 20;

            // Act
            _product.DecreaseStock(decreaseAmount);
            int actualStockAfterDecrease = _product.Stock;

            // Assert
            Assert.That(actualStockAfterDecrease, Is.EqualTo(30));
        }

        [Test]
        public void DecreaseStock_notIncrease()
        {
            // Assign
            int initialStock = _product.Stock;

            // Act
            _product.DecreaseStock(20);
            int decreasedStock = _product.Stock;

            // Assert
            Assert.That(decreasedStock, Is.EqualTo(initialStock - 20));
        }

        [Test]
        public void DecreaseStock_Exceptions()
        {
            // Assign
            int decreaseAmount = 60;

            // Act
            TestDelegate action = () => _product.DecreaseStock(decreaseAmount);

            // Assert
            Assert.That(action, Throws.InvalidOperationException);
        }
    }
}