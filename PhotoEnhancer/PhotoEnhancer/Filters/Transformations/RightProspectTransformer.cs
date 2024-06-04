using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters.Transformations
{
    public class RightProspectTransformer : ITransformer<RightProspectParameters>
    {
        double narrowingFactor;
        Size oldSize;
        public Size ResultSize { get; private set; }

        public void Initialize(Size oldSize, RightProspectParameters parameters)
        {
            this.oldSize = oldSize;
            narrowingFactor = parameters.PercentOfNarrowing / 100.0;
            ResultSize = oldSize;
        }

        public Point? MapPoint(Point newPoint)
        {
            int middleY = oldSize.Height / 2;

            double t = (double)newPoint.X / oldSize.Width;
            double coefficient = 1.0 - t * (1.0 - narrowingFactor);

            int x = newPoint.X;
            int y = (int)((newPoint.Y - middleY) / coefficient + middleY);

            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                return null;

            return new Point(x, y);
        }
    }
}