
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
        public void Test_rounding_no_special_treatment()
        {
            YogaConfig config = new YogaConfig() { Rounding = YogaRounding.NoSpecialTreatment };

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

            YogaNode meas = new YogaNode(config);
            meas.FlexDirection = YogaFlexDirection.Row;
            meas.SetMeasureFunction((a, b, c, d, e) => new YogaSize { width = 100f, height = 100.4f });
            meas.CalculateLayout();

            Assert.AreEqual(0f, meas.LayoutX);
            Assert.AreEqual(0f, meas.LayoutY);
            Assert.AreEqual(100f, meas.LayoutWidth);
            Assert.AreEqual(100f, meas.LayoutHeight);

            meas.SetMeasureFunction((a, b, c, d, e) => new YogaSize { width = 100f, height = 100.6f });
            meas.MarkDirty();
            meas.CalculateLayout();

            Assert.AreEqual(0f, meas.LayoutX);
            Assert.AreEqual(0f, meas.LayoutY);
            Assert.AreEqual(100f, meas.LayoutWidth);
            Assert.AreEqual(101f, meas.LayoutHeight);
        }

        [Test]
        public void Test_no_special_treatment_for_child_measure()
        {
            YogaConfig config = new YogaConfig() { Rounding = YogaRounding.NoSpecialTreatment };

            YogaNode root = new YogaNode(config);
            root.FlexDirection = YogaFlexDirection.Row;
            root.Width = 113;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode(config);
            root_child0.FlexGrow = 1;
            root.Insert(0, root_child0);

            YogaNode root_child1 = new YogaNode(config);
            root_child1.FlexGrow = 1;
            root.Insert(1, root_child1);

            YogaNode root_child2 = new YogaNode(config);
            root_child2.FlexGrow = 1;
            root.Insert(2, root_child2);

            YogaNode root_child3 = new YogaNode(config);
            root_child3.FlexGrow = 1;
            root.Insert(3, root_child3);

            YogaNode root_child4 = new YogaNode(config);
            root_child4.FlexGrow = 1;
            root.Insert(4, root_child4);
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(113f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(23f, root_child0.LayoutWidth, "w0");
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(23f, root_child1.LayoutX);
            Assert.AreEqual(0f, root_child1.LayoutY);
            Assert.AreEqual(22f, root_child1.LayoutWidth,"w1");
            Assert.AreEqual(100f, root_child1.LayoutHeight);

            Assert.AreEqual(45f, root_child2.LayoutX);
            Assert.AreEqual(0f, root_child2.LayoutY);
            Assert.AreEqual(23f, root_child2.LayoutWidth, "w2");
            Assert.AreEqual(100f, root_child2.LayoutHeight);

            Assert.AreEqual(68f, root_child3.LayoutX);
            Assert.AreEqual(0f, root_child3.LayoutY);
            Assert.AreEqual(22f, root_child3.LayoutWidth, "w3");
            Assert.AreEqual(100f, root_child3.LayoutHeight);

            Assert.AreEqual(90f, root_child4.LayoutX);
            Assert.AreEqual(0f, root_child4.LayoutY);
            Assert.AreEqual(23f, root_child4.LayoutWidth,"w4");
            Assert.AreEqual(100f, root_child4.LayoutHeight);

            MeasureFunction meas = (a, b, c, d, e) => new YogaSize { width = float.NaN, height = 100f };

            root_child0.SetMeasureFunction(meas);
            root_child1.SetMeasureFunction(meas);
            root_child2.SetMeasureFunction(meas);
            root_child3.SetMeasureFunction(meas);
            root_child4.SetMeasureFunction(meas);

            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(113f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(23f, root_child0.LayoutWidth, "w0");
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(23f, root_child1.LayoutX, "x");
            Assert.AreEqual(0f, root_child1.LayoutY);
            Assert.AreEqual(22f, root_child1.LayoutWidth, "w1");
            Assert.AreEqual(100f, root_child1.LayoutHeight);

            Assert.AreEqual(45f, root_child2.LayoutX);
            Assert.AreEqual(0f, root_child2.LayoutY);
            Assert.AreEqual(23f, root_child2.LayoutWidth, "w2");
            Assert.AreEqual(100f, root_child2.LayoutHeight);

            Assert.AreEqual(68f, root_child3.LayoutX);
            Assert.AreEqual(0f, root_child3.LayoutY);
            Assert.AreEqual(22f, root_child3.LayoutWidth, "w3");
            Assert.AreEqual(100f, root_child3.LayoutHeight);

            Assert.AreEqual(90f, root_child4.LayoutX);
            Assert.AreEqual(0f, root_child4.LayoutY);
            Assert.AreEqual(23f, root_child4.LayoutWidth, "w4");
            Assert.AreEqual(100f, root_child4.LayoutHeight);
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
