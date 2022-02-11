﻿using System.Collections.Generic;
using UnityEngine;

namespace TraceCurve
{
	public class TraceFiller : MonoBehaviour
	{
		public TracePainter TracePainter;
		public GeometryContainer GeometryContainer;

		private GeometryRange[] geometryRanges;
		private bool inited;
		private const float Eps = 0.005f;

		public void Init()
		{
			geometryRanges = new GeometryRange[GeometryContainer.SegmentsData.Count];
			var totalLength = 0f;
			for (var i = 0; i < GeometryContainer.SegmentsData.Count; i++)
			{
				var segments = GeometryContainer.SegmentsData[i];
				var lineLength = 0f;
				for (var j = 0; j < segments.Points.Length - 1; j++)
				{
					var p0 = segments.Points[j + 0];
					var p1 = segments.Points[j + 1];

					var distance = Vector2.Distance(p0, p1);
					lineLength += distance;
				}
				var previousRange = i > 0 ? geometryRanges[i - 1].End : 0f;
				var range = new GeometryRange
				{
					Geometry = segments.Object,
					Start = totalLength,
					End = lineLength + previousRange
				};
				totalLength += lineLength;
				geometryRanges[i] = range;
			}
		}

		public void UpdateProgress(float progress)
		{
			var geometry = 0;
			var point = 0;
			UpdateProgress(progress, out geometry, out point);
		}

		public void UpdateProgress(float progress, out int geometry, out int point)
		{
			if (!inited)
			{
				inited = true;
				Init();
			}
			var geometryId = geometryRanges.Length - 1;
			var pointId = 0;
			progress = Mathf.Clamp(progress, 0f, 1f);
			var totalProgress = geometryRanges[geometryRanges.Length - 1].End;
			var currentProgress = progress * totalProgress;
			for (var i = 0; i < geometryRanges.Length; i++)
			{
				var range = geometryRanges[i];
				if (range.Start <= currentProgress && range.End > currentProgress)
				{
					geometryId = i;
					break;
				}
			}

			Vector2? interpolatedPosition = null;
			var currentRange = geometryRanges[geometryId];
			var segmentLength = 0f;
			for (var j = 0; j < GeometryContainer.SegmentsData[geometryId].Points.Length - 1; j++)
			{
				var p0 = GeometryContainer.SegmentsData[geometryId].Points[j + 0];
				var p1 = GeometryContainer.SegmentsData[geometryId].Points[j + 1];
				var distance = Vector2.Distance(p0, p1);
				if (currentRange.Start + segmentLength < currentProgress &&
				    currentRange.Start + segmentLength + distance >= currentProgress - Eps)
				{
					pointId = j;
					var dir = p1 - p0;
					var start = currentRange.Start + segmentLength;
					var end = currentRange.Start + segmentLength + distance;
					var lineLength = (currentProgress - start) / (end - start);
					interpolatedPosition = p0 + dir * lineLength;
				}
				segmentLength += distance;
			}

			geometry = geometryId;
			point = pointId;
			
			if (currentRange != null)
			{
				TracePainter.Clear();
				var positions = new List<Vector2>();
				for (var i = 0; i <= geometryId; i++)
				{
					var segments = GeometryContainer.SegmentsData[i];

					if (!segments.Object.ShouldContinue)
					{
						Draw(positions, null);
						positions.Clear();
					}

					if (geometryId == i)
					{
						for (var j = 0; j <= pointId; j++)
						{
							positions.Add(segments.Points[j]);
						}

						if (interpolatedPosition != null)
						{
							positions.Add(interpolatedPosition.Value);
						}

						break;
					}

					for (var j = 0; j < segments.Points.Length; j++)
					{
						positions.Add(segments.Points[j]);
					}

					if (segments.Object == currentRange.Geometry)
					{
						break;
					}
				}
				Draw(positions, interpolatedPosition);
			}
		}

		public void UpdateGeometryProgress(int geometry)
		{
			if (!inited)
			{
				inited = true;
				Init();
			}
			var pointId = 0;
			Vector2? interpolatedPosition = null;
			var currentRange = geometryRanges[geometry];
			var segmentLength = 0f;
			for (var j = 0; j < GeometryContainer.SegmentsData[geometry].Points.Length - 1; j++)
			{
				var p0 = GeometryContainer.SegmentsData[geometry].Points[j + 0];
				var p1 = GeometryContainer.SegmentsData[geometry].Points[j + 1];
				var distance = Vector2.Distance(p0, p1);
				if (currentRange.Start + segmentLength < 0f &&
				    currentRange.Start + segmentLength + distance >= 0f - Eps)
				{
					pointId = j;
					var dir = p1 - p0;
					var start = currentRange.Start + segmentLength;
					var end = currentRange.Start + segmentLength + distance;
					var lineLength = -start / (end - start);
					interpolatedPosition = p0 + dir * lineLength;
				}
				segmentLength += distance;
			}

			if (currentRange != null)
			{
				TracePainter.Clear();
				var positions = new List<Vector2>();
				for (var i = 0; i <= geometry; i++)
				{
					var segments = GeometryContainer.SegmentsData[i];

					if (!segments.Object.ShouldContinue)
					{
						Draw(positions, null);
						positions.Clear();
					}

					if (geometry == i)
					{
						for (var j = 0; j <= pointId; j++)
						{
							positions.Add(segments.Points[j]);
						}

						if (interpolatedPosition != null)
						{
							positions.Add(interpolatedPosition.Value);
						}

						break;
					}

					for (var j = 0; j < segments.Points.Length; j++)
					{
						positions.Add(segments.Points[j]);
					}

					if (segments.Object == currentRange.Geometry)
					{
						break;
					}
				}
				Draw(positions, interpolatedPosition);
			}
		}

		private void Draw(List<Vector2> positions, Vector2? position)
		{
			if (position != null)
			{
				positions.Add(position.Value);
			}
			if (positions.Count > 0)
			{
				var lastPosition = positions[positions.Count - 1];
				var newPosition = new Vector3(lastPosition.x, lastPosition.y, TracePainter.BrushObject.transform.position.z);
				TracePainter.BrushObject.transform.position = newPosition;
				TracePainter.AddToRenderQueue(positions.ToArray());
			}
		}
	}
}