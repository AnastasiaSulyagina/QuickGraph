﻿using GraphX.Controls;
using GraphX.Controls.Models;
using GraphX.PCL.Common.Enums;
using GraphX.PCL.Common.Interfaces;
using GraphX.PCL.Logic.Algorithms.OverlapRemoval;
using GraphX.PCL.Logic.Models;

// Sample GraphArea and GXLogicCore config copied from GraphX examples.
// Feel free to inherit or modify.

namespace QuickGraph.GraphXAdapter
{
    public class BidirectionalGraphArea<TVertex, TEdge> : GraphArea<TVertex, TEdge, BidirectionalGraph<TVertex, TEdge>>
        where TVertex : class, IGraphXVertex
        where TEdge : class, IGraphXEdge<TVertex>
    {
        private static readonly GXLogicCore<TVertex, TEdge, BidirectionalGraph<TVertex, TEdge>> DefaultLogicCore =
            new GXLogicCore<TVertex, TEdge, BidirectionalGraph<TVertex, TEdge>>
            {
                DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.LinLog,
                DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA,
                DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.None,
                AsyncAlgorithmCompute = false,
                DefaultOverlapRemovalAlgorithmParams = new OverlapRemovalParameters { HorizontalGap = 50, VerticalGap = 50}
            };

        public BidirectionalGraphArea(GXLogicCore<TVertex, TEdge, BidirectionalGraph<TVertex, TEdge>> logicCore)
        {
            LogicCore = logicCore;
            EnableWinFormsHostingMode = true;
            EdgeLabelFactory = new DefaultEdgelabelFactory();
            SetVerticesDrag(true);

            logicCore.DefaultLayoutAlgorithmParams =
                logicCore.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.LinLog);
            logicCore.DefaultOverlapRemovalAlgorithmParams =
                logicCore.AlgorithmFactory.CreateOverlapRemovalParameters(OverlapRemovalAlgorithmTypeEnum.FSA);
        }

        public BidirectionalGraphArea() : this(DefaultLogicCore)
        {
        }
    }
}