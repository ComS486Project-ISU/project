	<!DOCTYPE html>

<html lang="en">
<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>CANanator Web Interface</title>
	
	<!-- Stylesheet stuff -->
		<link href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" rel="stylesheet">
		<link href="//getbootstrap.com/examples/sticky-footer/sticky-footer.css" rel="stylesheet">
		<link href="//necolas.github.io/normalize.css" rel="stylesheet">
		<link href="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/themes/smoothness/jquery-ui.css" rel="stylesheet">
		<!--<link href="//cdnjs.cloudflare.com/ajax/libs/rickshaw/1.4.6/rickshaw.css" rel="stylesheet">-->
	
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
		<li class="active"><a href="#bps" data-toggle="tab">Battery Protection (BPS)</a></li>
		<li><a href="#mppt" data-toggle="tab">Power Trackers (MPPT)</a></li>
		<li><a href="#motor" data-toggle="tab">Motor</a></li>
		<li><a href="#errorlog" data-toggle="tab">Error Log</a></li>
		<li><a href="#graphs" data-toggle="tab">Graphs</a></li>
	</ul>

<!-- Tab panes (LOWER CONTENT) -->
	<div class="tab-content">
		<div class="tab-pane active" id="bps">
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
		<div class="tab-pane" id="graphs">
			<div class="panel panel-default">
  				<div class="panel-body">
 					<div id="chart"></div>
					<div id="legend"></div>
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
		<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
		<script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/jquery-ui.min.js"></script>
	
	<!-- Include all compiled plugins (below), or include individual files as needed -->
		<script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>

	<!--Chart script stuff using Rickshaw.js charting.  See Rickshaw website http://code.shutterstock.com/rickshaw/ for example with dynamic updating -->
		<script src="//cdnjs.cloudflare.com/ajax/libs/d3/3.4.5/d3.js"></script>
		<script src="//cdnjs.cloudflare.com/ajax/libs/rickshaw/1.4.6/rickshaw.js"></script>

		<script>
		//x-value is epoch referenced time
		var speed = [ { x: 1397704200, y: 15 }, { x: 1397704260, y: 20 }, { x: 1397704320, y: 30 }, { x: 1397704380, y: 34 }, { x: 1397704440, y: 32 } ];
		var power = [ { x: 1397704200, y: 40 }, { x: 1397704260, y: 49 }, { x: 1397704320, y: 38 }, { x: 1397704380, y: 30 }, { x: 1397704440, y: 35 } ];
		var charge = [ { x: 1397704200, y: 90 }, { x: 1397704260, y: 88 }, { x: 1397704320, y: 87 }, { x: 1397704380, y: 86 }, { x: 1397704440, y: 85 } ];
		
		var graph = new Rickshaw.Graph({
			element: document.querySelector("#chart"),
			//width: 800,
			height: 300,
			renderer: 'line',
			series: [{
					data: speed,
					color: 'red',
					name: "Speed"
				}, {
					data: power,
					color: 'blue',
					name: "Power Consumption"
				}, {
					data: charge,
					color: 'green',
					name: "Charge State"
			}]
		});
		
		graph.render();
		
		//x-axis setup
		var x_Axis = new Rickshaw.Graph.Axis.Time({
			graph: graph
		});

		x_Axis.render();

		//hover over chart info pop-up
		var hoverDetail = new Rickshaw.Graph.HoverDetail( {
			graph: graph,
			formatter: function(series, x, y) {
				var date = '<span class="date">' + new Date(x * 1000).toUTCString() + '</span>';
				var swatch = '<span class="detail_swatch" style="background-color: ' + series.color + '"></span>';
				var content = swatch + series.name + ": " + parseInt(y) + '<br>' + date;
				return content;
			}
		} );
		
		//creates legend
		var legend = new Rickshaw.Graph.Legend( {
			graph: graph,
			element: document.getElementById('legend')
		} );

		//line toggle via legend
		var shelving = new Rickshaw.Graph.Behavior.Series.Toggle({
			graph: graph,
			legend: legend
		});

		</script>


</body>
</html>
