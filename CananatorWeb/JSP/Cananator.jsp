	<!DOCTYPE html>

<html lang="en">
<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>CANanator Web Interface</title>
	
	<!-- Stylesheet stuff -->
		<link href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
		<link href="//getbootstrap.com/examples/sticky-footer/sticky-footer.css" rel="stylesheet" type="text/css" />
		<link href="//necolas.github.io/normalize.css" rel="stylesheet" type="text/css" />
		<link href="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />

	
		<!-- Styles for chart hover -->
		<style>
			.rickshaw_graph .detail .x_label { display: none }
			.rickshaw_graph .detail .item { line-height: 1.4; padding: 0.5em }
			.detail_swatch { float: right; display: inline-block; width: 10px; height: 10px; margin: 0 4px 0 0 }
			.rickshaw_graph .detail .date { color: #a0a0a0 }
		</style>

</head>
<body>

<!-- HEADER AREA -->

<div class="navbar navbar-default navbar-static-top">
	<div class="navbar-header">
		<div class="navbar-brand">CANanator Web Interface</div>
	</div>
</div>

<!-- UPPER CONTENT AREA -->

<div class="jumbotron">
	<div class="container">
		<div class="row">
			<div class="col-xs-10 col-sm-6 col-md-3 col-lg-3">
				<div class="table">
					<table class="table table-striped table-condensed table-bordered">
						<thead>
						<tr>
							<th>Vehicle Info</th>
							<th>Status</th>
						</tr>
						</thead>
						<tbody>
						<tr>
							<td>Driving Direction</td>
							<td>${key.getMessage()}</td>
						</tr>
						<tr>
							<td>Throttle Position</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Motor Limiting</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Trip Odometer (<abbr title="Miles">mi</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Vehicle Odometer (<abbr title="Miles">mi</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Battery Status</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Battery Cycles</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>State of Charge</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Battery Capacity (<abbr title="Kilowatt Hours">kWh</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>High Module (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>High Module (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Low Module (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						</tbody>
					</table>
				</div>
			</div>
			<div class="col-xs-12 col-sm-10 col-md-6 col-lg-6">
				<div class="table">
					<table class="table table-striped table-condensed table-bordered">
						<thead>
						<tr>
							<th>Runtime Stats</th>
							<th>Current</th>
							<th>Recent</th>
							<th>Average</th>
							<th><abbr title="Maximum">Max.</abbr></th>
							<th><abbr title="Minimum">Min.</abbr></th>
						</tr>
						</thead>
						<tbody>
						<tr>
							<td>Driving Speed (<abbr title="Miles per Hour">MPH</abbr>)</td>
							<td>${telemetryData.drivingSpeed}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Energy Consumption (<abbr title="Mile per Gallon Equivalent">MPGe</abbr>)</td>
							<td>${telemetryData.energyConsumption}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td><abbr title="Power Tracker">MPPT</abbr> Efficiency</td>
							<td>${telemetryData.mpptEfficiency}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Battery Pack Power (<abbr title="Watts">W</abbr>)</td>
							<td>${telemetryData.batteryPower}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Solar Array Power (<abbr title="Watts">W</abbr>)</td>
							<td>${telemetryData.solarPower}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Motor Power (<abbr title="Watts">W</abbr>)</td>
							<td>${telemetryData.motorPower}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Electronics Power (<abbr title="Watts">W</abbr>)</td>
							<td>${telemetryData.elecPower}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Cockpit Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>${telemetryData.cockpitTemp}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Motor Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>${telemetryData.motorTemp}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Controller Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>${telemetryData.controlTemp}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Baseplate Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>${telemetryData.baseplateTemp}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Battery Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>${telemetryData.batteryTemp}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td><abbr title="Power Tracker">MPPT</abbr> Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>${telemetryData.mpptTemp}</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						</tbody>
					</table>
				</div>
			</div>
			<div class="col-xs-10 col-sm-5 col-md-3 col-lg-3">
				<div class="table">
					<table class="table table-striped table-condensed table-bordered">
						<thead>
						<tr>
							<th>System</th>
							<th>Current (<abbr title="Amperes">A</abbr>)</th>
							<th>State</th>
						</tr>
						</thead>
						<tbody>
						<tr>
							<td>Pack</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Array</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Motor</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						</tbody>
					</table>
				</div>
			</div>
			<div class="col-xs-10 col-sm-5 col-md-3 col-lg-3">
				<div class="table">
					<table class="table table-striped table-condensed table-bordered">
						<thead>
						<tr>
							<th>Vehicle Voltage</th>
							<th>Value</th>
						</tr>
						</thead>
						<tbody>
						<tr>
							<td>System Voltage (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>No Load Voltage (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Recent Voltage (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Module Range (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td><abbr title="Auxiliary">Aux.</abbr> Pack (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td><abbr title="Auxiliary">Aux.</abbr> Pack Level (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>12V Main Bus (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>12V <abbr title="Auxiliary">Aux.</abbr> Bus (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>5V Bus (<abbr title="Volts">V</abbr>)</td>
							<td>[Status]</td>
						</tr>
						</tbody>
					</table>
				</div>
			</div>
		</div>
	</div>
</div>



<!-- NAVIGATION BAR -->
<!--<div class="container"> -->
	<!-- Nav tabs -->
	<ul class="nav nav-tabs">
		<li><a href="#bps" data-toggle="tab">Battery Protection (BPS)</a></li>
		<li><a href="#mppt" data-toggle="tab">Power Trackers (MPPT)</a></li>
		<li><a href="#motor" data-toggle="tab">Motor</a></li>
		<li><a href="#errorlog" data-toggle="tab">Error Log</a></li>
		<li class="active"><a href="#graphs" data-toggle="tab">Graphs</a></li>
	</ul>

<!-- Tab panes (LOWER CONTENT) -->
	<div class="tab-content">
		<div class="tab-pane" id="bps">
				<div class="panel panel-default">
  				<div class="panel-body">
  					<h4>BPS Content</h4>
  					<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui.</p>
					</div>
  			</div>
		</div>
		<div class="tab-pane" id="mppt">
			<div class="panel panel-default">
  				<div class="panel-body">
  					<h4>MPPT Content</h4>
  					<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui.</p>
				</div>
  			</div>
		</div>
		<div class="tab-pane" id="motor">
			<div class="panel panel-default">
  				<div class="panel-body">
  					<h4>Motor Content</h4>
  					<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui.</p>
				</div>
  			</div>
		</div>
		<div class="tab-pane" id="errorlog">
			<div class="panel panel-default">
  				<div class="panel-body">
  					<h4>Error Content</h4>
  					<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui.</p>
				</div>
  			</div>
		</div>
		<div class="tab-pane active" id="graphs">
			<div class="panel panel-default">
  				<div class="panel-body">
 					<div align="center">
	 					<div id="GoogleChart" style="height:350px; width:80%;"> 					
					</div>
 					<div align="center">
	 					<div id="jqPlotLive" style="height:350px; width:80%;"></div>
						<button>Start Updates</button>
					</div>
				</div>
  			</div>
		</div>
	</div>


<!-- FOOTER -->
<div height="50">&nbsp;</div>
<div id="footer">
	<p class="text-muted">&copy; 2014 Scott - Dalhoff - Jenkins - Sogge</p>
</div>



<!-- JAVASCRIPT -->

	<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
		<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js" type="text/javascript"></script>
		<script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/jquery-ui.min.js" type="text/javascript"></script>
	
	<!-- Include all compiled plugins (below), or include individual files as needed -->
		<script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js" type="text/javascript"></script>

	<!--Google Chart script stuff -->
		<script src="https://www.google.com/jsapi" type="text/javascript"></script>
		<script type="text/javascript">
			google.load("visualization", "1", {packages:["corechart"]});
			google.setOnLoadCallback(drawChart);
			function drawChart() {
				var data = google.visualization.arrayToDataTable([
					['Year',	'Sales',	'Expenses'],
					['2004',	1000,		400],
					['2005',	1170,		460],
					['2006',	660,		1120],
					['2007',	1030,		540]
				]);
	
				var options = {
					title: 'Company Performance',
				};
	
				var chart = new google.visualization.LineChart(document.getElementById('GoogleChart'));
				
				chart.draw(data, options);
			}
	</script>


	<!-- jqPlot stuff -->
	<link href="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/jquery.jqplot.min.css" rel="stylesheet" type="text/css" />
	<script src="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/jquery.jqplot.min.js" type="text/javascript"></script>
	<script src="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/plugins/jqplot.dateAxisRenderer.min.js" type="text/javascript"></script>

	<script type="text/javascript">
		//jqPlot with real time update example http://www.meccanismocomplesso.org/en/jqplot-real-time-data/
		
		$(document).ready(function () {
			var t = 5000;	//refresh time (in millisec)
			var n = 40;		//samples to draw
			var x = (new Date()).getTime();	// current time
			var data = [];	//buffer of n samples
			for (i = 0; i < n; i++) {
				data.push([x - (n - 1 - i) * t, 0]);
			}
	
			var options = {
				axes: {
					xaxis: {
						numberTicks: 10,
						renderer: $.jqplot.DateAxisRenderer,
						tickOptions: { formatString: '%H:%M:%S' },
						min: data[0][0],
						max: data[data.length - 1][0]
					},
					yaxis: {
						min: 0,
						max: 1, // reset to maximum scale
						numberTicks: 6,
						tickOptions: { formatString: '%.1f'	}
					}
				},
				seriesDefaults: { rendererOptions: { smooth: false } } // curved lines or linear
			};
			
			var plot1 = $.jqplot('jqPlotLive', [data], options);
	
			$('button').click(function () {
				doUpdate();
				$(this).hide();
			});
	
			function doUpdate() {
				if (data.length > n - 1) {
					data.shift();
				}
				var y = Math.random(); // y variable data is a random generated number in this example
				var x = (new Date()).getTime();
				data.push([x, y]);
				if (plot1) {
					plot1.destroy();
				}
				
				plot1.series[0].data = data;

				// the problem is that now the values ​​on the y ticks are no longer static
				// and change with each update, and then change the underlying logic
				// need to adjust the values ​​in options.

				options.axes.xaxis.min = data[0][0];
				options.axes.xaxis.max = data[data.length - 1][0];
				plot1 = $.jqplot('jqPlotLive', [data], options);
				setTimeout(doUpdate, t);
			}	
		});
	</script>






</body>
</html>
