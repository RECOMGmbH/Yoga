
using NUnit.Framework;

namespace Facebook.Yoga
{
    [TestFixture]
    class YGExplicitRoundingTest
    {
        [Test]
        public void Test_rounding_default()
        {
            YogaConfig config = new YogaConfig() { Rounding = YogaRounding.Default };

            YogaNode root = new YogaNode(config);
            root.FlexDirection = YogaFlexDirection.Row;
            root.Width = 100;
            root.Height = 100.4f;

            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);
            
            root.Height = 100.6f;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(101f, root.LayoutHeight);
        }

        [Test]
        public void Test_rounding_disabled()
        {
            YogaConfig config = new YogaConfig() { Rounding = YogaRounding.Disabled };

            YogaNode root = new YogaNode(config);
            root.FlexDirection = YogaFlexDirection.Row;
            root.Width = 100;
            root.Height = 100.4f;

            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100.4f, root.LayoutHeight);

            root.Height = 100.6f;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100.6f, root.LayoutHeight);
        }

        [Test]
        public void Test_rounding_force_ceil()
        {
            YogaConfig config = new YogaConfig() { Rounding = YogaRounding.ForceCeil };

            YogaNode root = new YogaNode(config);
            root.FlexDirection = YogaFlexDirection.Row;
            root.Width = 100;
            root.Height = 100.4f;

            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(101f, root.LayoutHeight);

            root.Height = 100.6f;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(101f, root.LayoutHeight);
        }

        [Test]
        public void Test_rounding_force_floor()
        {
            YogaConfig config = new YogaConfig() { Rounding = YogaRounding.ForceFloor };

            YogaNode root = new YogaNode(config);
            root.FlexDirection = YogaFlexDirection.Row;
            root.Width = 100;
            root.Height = 100.4f;

            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            root.Height = 100.6f;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);
        }

    }
}
