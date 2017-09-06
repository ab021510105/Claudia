/**
 * @namespace Chart
 */
var Chart = require(['../../Desk/Chart.js-master/src/core/core.js'])();

require(['../../Desk/Chart.js-master/src/core/core.helpers'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.canvasHelpers'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.plugin.js'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.element'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.animation'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.controller'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.datasetController'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.layoutService'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.scaleService'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.ticks.js'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.scale'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.title'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.legend'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.interaction'])(Chart);
require(['../../Desk/Chart.js-master/src/core/core.tooltip'])(Chart);

// By default, we only load the browser platform.
Chart.platform = require(['./platforms/platform.dom'])(Chart);

require(['../../Desk/Chart.js-master/src/elements/element.arc'])(Chart);
require(['../../Desk/Chart.js-master/src/elements/element.line'])(Chart);
require(['../../Desk/Chart.js-master/src/elements/element.point'])(Chart);
require(['../../Desk/Chart.js-master/src/elements/element.rectangle'])(Chart);

require(['../../Desk/Chart.js-master/src/scales/scale.linearbase.js'])(Chart);
require(['../../Desk/Chart.js-master/src/scales/scale.category'])(Chart);
require(['../../Desk/Chart.js-master/src/scales/scale.linear'])(Chart);
require(['../../Desk/Chart.js-master/src/scales/scale.logarithmic'])(Chart);
require(['../../Desk/Chart.js-master/src/scales/scale.radialLinear'])(Chart);
require(['../../Desk/Chart.js-master/src/scales/scale.time'])(Chart);

// Controllers must be loaded after elements
// See Chart.core.datasetController.dataElementType
require(['../../Desk/Chart.js-master/src/controllers/controller.bar'])(Chart);
require(['../../Desk/Chart.js-master/src/controllers/controller.bubble'])(Chart);
require(['../../Desk/Chart.js-master/src/controllers/controller.doughnut'])(Chart);
require(['../../Desk/Chart.js-master/src/controllers/controller.line'])(Chart);
require(['../../Desk/Chart.js-master/src/controllers/controller.polarArea'])(Chart);
require(['../../Desk/Chart.js-master/src/controllers/controller.radar'])(Chart);

require(['../../Desk/Chart.js-master/src/charts/Chart.Bar'])(Chart);
require(['../../Desk/Chart.js-master/src/charts/Chart.Bubble'])(Chart);
require(['../../Desk/Chart.js-master/src/charts/Chart.Doughnut'])(Chart);
require(['../../Desk/Chart.js-master/src/charts/Chart.Line'])(Chart);
require(['../../Desk/Chart.js-master/src/charts/Chart.PolarArea'])(Chart);
require(['../../Desk/Chart.js-master/src/charts/Chart.Radar'])(Chart);
require(['../../Desk/Chart.js-master/src/charts/Chart.Scatter'])(Chart);

window.Chart = module.exports = Chart;
