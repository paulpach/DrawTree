using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawTreeTest
{
    public partial class Form1 : Form
    {
        private const int NODE_HEIGHT = 30;
        private const int NODE_WIDTH = 30;
        private const int NODE_MARGIN_X = 50;
        private const int NODE_MARGIN_Y = 40;

        private static Pen NODE_PEN = Pens.Gray;

        private List<SampleDataModel> _data;
        private TreeNodeModel<SampleDataModel> _tree;

        public Form1()
        {
            InitializeComponent();

            _data = GetSampleData();
            _tree = GetSampleTree(_data);
            TreeHelpers<SampleDataModel>.CalculateNodePositions(_tree);

            CalculateControlSize();

            DoubleBuffered = true;
            treePanel.Paint += treePanel_Paint;
        }

        #region Tree Setup Helpers

        // returns a list of sample data items
        private List<SampleDataModel> GetSampleData()
        {
            var sampleTree = new List<SampleDataModel>();

            /*
             // Root Node
             sampleTree.Add(new SampleDataModel { Id = "O", ParentId = string.Empty, Name = "Test GP O" });

             // 1st Level
             sampleTree.Add(new SampleDataModel { Id = "E", ParentId = "O", Name = "Test Node E" });
             sampleTree.Add(new SampleDataModel { Id = "F", ParentId = "O", Name = "Test Node F" });
             sampleTree.Add(new SampleDataModel { Id = "N", ParentId = "O", Name = "Test Node N" });

             // 2nd Level
             sampleTree.Add(new SampleDataModel { Id = "A", ParentId = "E", Name = "Test Node A" });
             sampleTree.Add(new SampleDataModel { Id = "D", ParentId = "E", Name = "Test Node D" });

             sampleTree.Add(new SampleDataModel { Id = "G", ParentId = "N", Name = "Test Node G" });
             sampleTree.Add(new SampleDataModel { Id = "M", ParentId = "N", Name = "Test Node M" });

             // 3rd Level
             sampleTree.Add(new SampleDataModel { Id = "B", ParentId = "D", Name = "Test Node B" });
             sampleTree.Add(new SampleDataModel { Id = "C", ParentId = "D", Name = "Test Node C" });

             sampleTree.Add(new SampleDataModel { Id = "H", ParentId = "M", Name = "Test Node H" });
             sampleTree.Add(new SampleDataModel { Id = "I", ParentId = "M", Name = "Test Node I" });
             sampleTree.Add(new SampleDataModel { Id = "J", ParentId = "M", Name = "Test Node J" });
             sampleTree.Add(new SampleDataModel { Id = "K", ParentId = "M", Name = "Test Node K" });
             sampleTree.Add(new SampleDataModel { Id = "L", ParentId = "M", Name = "Test Node L" });

        */

            /*
            sampleTree.Add(new SampleDataModel { Id = "O", ParentId = string.Empty, Name = "Test GP O" });
            sampleTree.Add(new SampleDataModel { Id = "N", ParentId = "O", Name = "Test Node N" });
            sampleTree.Add(new SampleDataModel { Id = "F", ParentId = "O", Name = "Test Node F" });
            sampleTree.Add(new SampleDataModel { Id = "E", ParentId = "O", Name = "Test Node E" });
            sampleTree.Add(new SampleDataModel { Id = "2", ParentId = "F", Name = "Test Node F" });
            sampleTree.Add(new SampleDataModel { Id = "B", ParentId = "N", Name = "Test Node N" });
            sampleTree.Add(new SampleDataModel { Id = "A", ParentId = "E", Name = "Test Node A" });
            sampleTree.Add(new SampleDataModel { Id = "D", ParentId = "E", Name = "Test Node D" });
            sampleTree.Add(new SampleDataModel { Id = "Z", ParentId = "E", Name = "Test Node D" });
            sampleTree.Add(new SampleDataModel { Id = "Y", ParentId = "A", Name = "Test Node A" });
            sampleTree.Add(new SampleDataModel { Id = "Q", ParentId = "A", Name = "Test Node A" });
            sampleTree.Add(new SampleDataModel { Id = "U", ParentId = "D", Name = "Test Node A" });
            sampleTree.Add(new SampleDataModel { Id = "W", ParentId = "D", Name = "Test Node A" });
            sampleTree.Add(new SampleDataModel { Id = "R", ParentId = "Z", Name = "Test Node D" });
            */

            sampleTree.Add(new SampleDataModel { Id = "TO", ParentId = string.Empty, Name = "Test GP O" });
            sampleTree.Add(new SampleDataModel { Id = "JW", ParentId = "TO", Name = "TO" });
            sampleTree.Add(new SampleDataModel { Id = "BK", ParentId = "JW", Name = "JW" });
            sampleTree.Add(new SampleDataModel { Id = "WH", ParentId = "BK", Name = "BK" });
            sampleTree.Add(new SampleDataModel { Id = "SE", ParentId = "BK", Name = "BK" });
            sampleTree.Add(new SampleDataModel { Id = "QI", ParentId = "BK", Name = "BK" });
            sampleTree.Add(new SampleDataModel { Id = "KX", ParentId = "BK", Name = "BK" });
            sampleTree.Add(new SampleDataModel { Id = "KA", ParentId = "KX", Name = "KX" });
            sampleTree.Add(new SampleDataModel { Id = "HH", ParentId = "JW", Name = "JW" });
            sampleTree.Add(new SampleDataModel { Id = "DN", ParentId = "HH", Name = "HH" });
            sampleTree.Add(new SampleDataModel { Id = "KT", ParentId = "HH", Name = "HH" });
            sampleTree.Add(new SampleDataModel { Id = "JB", ParentId = "KT", Name = "KT" });
            sampleTree.Add(new SampleDataModel { Id = "UM", ParentId = "KT", Name = "KT" });
            sampleTree.Add(new SampleDataModel { Id = "AL", ParentId = "KT", Name = "KT" });
            sampleTree.Add(new SampleDataModel { Id = "FR", ParentId = "KT", Name = "KT" });
            sampleTree.Add(new SampleDataModel { Id = "WE", ParentId = "HH", Name = "HH" });
            sampleTree.Add(new SampleDataModel { Id = "CO", ParentId = "WE", Name = "WE" });
            sampleTree.Add(new SampleDataModel { Id = "LE", ParentId = "WE", Name = "WE" });
            sampleTree.Add(new SampleDataModel { Id = "LO", ParentId = "WE", Name = "WE" });
            sampleTree.Add(new SampleDataModel { Id = "YI", ParentId = "HH", Name = "HH" });
            sampleTree.Add(new SampleDataModel { Id = "EI", ParentId = "YI", Name = "YI" });
            sampleTree.Add(new SampleDataModel { Id = "DJ", ParentId = "YI", Name = "YI" });
            sampleTree.Add(new SampleDataModel { Id = "SH", ParentId = "YI", Name = "YI" });
            sampleTree.Add(new SampleDataModel { Id = "BS", ParentId = "JW", Name = "JW" });
            sampleTree.Add(new SampleDataModel { Id = "SP", ParentId = "BS", Name = "BS" });
            sampleTree.Add(new SampleDataModel { Id = "SB", ParentId = "JW", Name = "JW" });
            sampleTree.Add(new SampleDataModel { Id = "GQ", ParentId = "SB", Name = "SB" });
            sampleTree.Add(new SampleDataModel { Id = "JS", ParentId = "GQ", Name = "GQ" });
            sampleTree.Add(new SampleDataModel { Id = "HT", ParentId = "SB", Name = "SB" });
            sampleTree.Add(new SampleDataModel { Id = "MB", ParentId = "HT", Name = "HT" });
            sampleTree.Add(new SampleDataModel { Id = "MF", ParentId = "HT", Name = "HT" });
            sampleTree.Add(new SampleDataModel { Id = "FW", ParentId = "SB", Name = "SB" });
            sampleTree.Add(new SampleDataModel { Id = "GM", ParentId = "FW", Name = "FW" });
            sampleTree.Add(new SampleDataModel { Id = "XT", ParentId = "FW", Name = "FW" });
            sampleTree.Add(new SampleDataModel { Id = "VQ", ParentId = "FW", Name = "FW" });

            return sampleTree;
        }

        // converts list of sample items to hierarchial list of TreeNodeModels
        private TreeNodeModel<SampleDataModel> GetSampleTree(List<SampleDataModel> data)
        {
            var root = data.FirstOrDefault(p => p.ParentId == string.Empty);
            var rootTreeNode = new TreeNodeModel<SampleDataModel>(root, null);

            // add tree node children recursively
            rootTreeNode.Children = GetChildNodes(data, rootTreeNode);

            return rootTreeNode;
        }

        private static List<TreeNodeModel<SampleDataModel>> GetChildNodes(List<SampleDataModel> data, TreeNodeModel<SampleDataModel> parent)
        {
            var nodes = new List<TreeNodeModel<SampleDataModel>>();

            foreach (var item in data.Where(p => p.ParentId == parent.Item.Id))
            {
                var treeNode = new TreeNodeModel<SampleDataModel>(item, parent);
                treeNode.Children = GetChildNodes(data, treeNode);
                nodes.Add(treeNode);
            }

            return nodes;
        }

        #endregion

        #region Custom Painting

        private void treePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            DrawNode(_tree, e.Graphics);
        }

        private void CalculateControlSize()
        {
            // tree sizes are 0-based, so add 1
            var treeWidth = _tree.Width + 1;
            var treeHeight = _tree.Height + 1;

            treePanel.Size = new Size(
                Convert.ToInt32((treeWidth * NODE_WIDTH) + ((treeWidth + 1) * NODE_MARGIN_X)),
                (treeHeight * NODE_HEIGHT) + ((treeHeight + 1) * NODE_MARGIN_Y));
        }

        private void DrawNode(TreeNodeModel<SampleDataModel> node, Graphics g)
        {
            // rectangle where node will be positioned
            var nodeRect = new Rectangle(
                Convert.ToInt32(NODE_MARGIN_X + (node.X * (NODE_WIDTH + NODE_MARGIN_X))),
                NODE_MARGIN_Y + (node.Y * (NODE_HEIGHT + NODE_MARGIN_Y))
                , NODE_WIDTH, NODE_HEIGHT);

            // draw box
            g.DrawRectangle(NODE_PEN, nodeRect);

            // draw content
            g.DrawString(node.ToString(), this.Font, Brushes.Black, nodeRect.X + 10, nodeRect.Y + 10);

            // draw line to parent
            if (node.Parent != null)
            {
                var nodeTopMiddle = new Point(nodeRect.X + (nodeRect.Width / 2), nodeRect.Y);
                g.DrawLine(NODE_PEN, nodeTopMiddle, new Point(nodeTopMiddle.X, nodeTopMiddle.Y - (NODE_MARGIN_Y / 2)));
            }

            // draw line to children
            if (node.Children.Count > 0)
            {
                var nodeBottomMiddle = new Point(nodeRect.X + (nodeRect.Width / 2), nodeRect.Y + nodeRect.Height);
                g.DrawLine(NODE_PEN, nodeBottomMiddle, new Point(nodeBottomMiddle.X, nodeBottomMiddle.Y + (NODE_MARGIN_Y / 2)));


                // draw line over children
                if (node.Children.Count > 1)
                {
                    var childrenLineStart = new Point(
                        Convert.ToInt32(NODE_MARGIN_X + (node.GetRightMostChild().X * (NODE_WIDTH + NODE_MARGIN_X)) + (NODE_WIDTH / 2)),
                        nodeBottomMiddle.Y + (NODE_MARGIN_Y / 2));
                    var childrenLineEnd = new Point(
                        Convert.ToInt32(NODE_MARGIN_X + (node.GetLeftMostChild().X * (NODE_WIDTH + NODE_MARGIN_X)) + (NODE_WIDTH / 2)),
                        nodeBottomMiddle.Y + (NODE_MARGIN_Y / 2));

                    g.DrawLine(NODE_PEN, childrenLineStart, childrenLineEnd);
                }
            }


            foreach (var item in node.Children)
            {
                DrawNode(item, g);
            }
        }

        #endregion
    }
}
