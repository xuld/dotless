/* Copyright 2009 dotless project, http://www.dotlesscss.com
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 *     
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License. */

using System.Linq;

namespace dotless.Core.engine.Functions
{
    public class HslaFunction : FunctionBase
    {
        public override INode Evaluate()
        {
            if (!Arguments.All(arg => arg is Number) || !(Arguments.Length == 4))
            {
                throw new exceptions.ParsingException("Expected 4 numeric arguments for HSLA color.");
            }

            var args = Arguments
              .Cast<Number>()
              .Select(n => n.Value)
              .ToArray();

            var hue = args[0] / 360d;
            var saturation = args[1] / 100d;
            var lightness = args[2] / 100d;
            var alpha = args[3];

            var hsl = new HslColor(hue, saturation, lightness, alpha);

            return hsl.ToRgbColor();
        }
    }

    public class HslFunction : HslaFunction
    {
        public override INode Evaluate()
        {
            if (!Arguments.All(arg => arg is Number) || !(Arguments.Length == 3))
            {
                throw new exceptions.ParsingException("Expected 3 numeric arguments for HSL color.");
            }

            Arguments = Arguments.Concat(new[] { new Number(1) }).ToArray();

            return base.Evaluate();
        }
    }
}