﻿// Copyright 2020 Jamie Taylor
//
// To facilitate other mods which would like to use the RangeHighlight API,
// the license for this file (and only this file) is modified by removing the
// notice requirements for binary distribution.  The license (as amended)
// is included below, making this file self-contained.
//
// In other words, anyone may copy this file into their own mod.
//

//  Copyright(c) 2020, Jamie Taylor
//All rights reserved.
//
//Redistribution and use in source and binary forms, with or without
//modification, are permitted provided that the following conditions are met:
//
//1.Redistributions of source code must retain the above copyright notice, this
//   list of conditions and the following disclaimer.
//
//2. [condition removed for this file]
//
//3. Neither the name of the copyright holder nor the names of its
//   contributors may be used to endorse or promote products derived from
//   this software without specific prior written permission.
//
//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
//AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
//FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
//DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
//SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
//CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
//OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
//OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley.Buildings;

namespace RangeHighlight {
    public interface IRangeHighlightAPI {

        // ----- Helpers for making highlight shapes -----

        /// <summary>
        ///   Return a circle shape (i.e., the shape of a scarecrow's range)
        /// </summary>
        /// <param name="radius">The circle radius</param>
        /// <param name="excludeCenter">whether the center tile should be excluded</param>
        bool[,] GetCartesianCircle(uint radius, bool excludeCenter = true);

        /// <summary>
        ///   Return a "circle" using Manhattan distance from the center (i.e., the shape of a beehouse's range)
        /// </summary>
        /// <param name="radius">The Manhattan distance from the center to be included in the shape</param>
        /// <param name="excludeCenter">whether the center tile should be excluded</param>
        bool[,] GetManhattanCircle(uint radius, bool excludeCenter = true);

        /// <summary>
        ///   Return a square with each side  2 * radius + 1 tiles (i.e., the shape of a sprinkler's range)
        /// </summary>
        /// <param name="radius">The x or y distance from the center to be included in the shape</param>
        /// <param name="excludeCenter">whether the center tile should be excluded</param>
        bool[,] GetSquareCircle(uint radius, bool excludeCenter = true);

        // ----- Getters for the currently configured tint colors ----

        /// <summary>Returns the currently configured tint for Junimo hut range highlighting</summary>
        Color GetJunimoRangeTint();
        /// <summary>Returns the currently configured tint for sprinkler range highlighting</summary>
        Color GetSprinklerRangeTint();
        /// <summary>Returns the currently configured tint for scarecrow range highlighting</summary>
        Color GetScarecrowRangeTint();
        /// <summary>Returns the currently configured tint for beehouse range highlighting</summary>
        Color GetBeehouseRangeTint();

        // ----- Hooks for applying highlights ----

        /// <summary>Add a highlighter for buildings.</summary>
        /// <param name="uniqueId">
        ///   An ID by which the highlighter can be removed later.
        ///   Best practice is for it to contain your mod's unique ID.
        /// </param>
        /// <param name="hotkey">Also apply the highlighter when this key is held</param>
        /// <param name="highlighter">
        ///   A function that evaluates whether the <c>Building</c> matches
        ///   this highlighter, and if so returns <c>Tuple</c> containing the tint
        ///   color, highlight shape, and x and y offset for the building "center".
        ///   If the building does not match then
        ///   the function should return <c>null</c>.  (Note that returning an
        ///   empty <c>bool[,]</c> will result in no highlighting, but counts
        ///   as a match so that no other highlighters will be processed for the building</param>
        void AddBuildingRangeHighlighter(string uniqueId, SButton? hotkey, Func<Building,Tuple<Color,bool[,],int,int>> highlighter);
        /// <summary>
        ///   Remove any building range highlighters added with the given <c>uniqueId</c>
        /// </summary>
        void RemoveBuildingRangeHighlighter(string uniqueId);
        /// <summary>Add a highlighter for items.</summary>
        /// <param name="uniqueId">
        ///   An ID by which the highlighter can be removed later.
        ///   Best practice is for it to contain your mod's unique ID.
        /// </param>
        /// <param name="hotkey">Also apply the highlighter when this key is held</param>
        /// <param name="highlighter">
        ///   A function that evaluates whether the lower-cased item name matches
        ///   this highlighter, and if so returns <c>Tuple</c> containing the tint
        ///   color and highlight shape.  If the item name does not match then
        ///   the function should return <c>null</c>.  (Note that returning an
        ///   empty <c>bool[,]</c> will result in no highlighting, but counts
        ///   as a match so that no other highlighters will be processed for the item</param>
        void AddItemRangeHighlighter(string uniqueId, SButton? hotkey, Func<string, Tuple<Color, bool[,]>> highlighter);
        /// <summary>
        ///   Remove any item range highlighters added with the given <c>uniqueId</c>
        /// </summary>
        void RemoveItemRangeHighlighter(string uniqueId);

    }
}