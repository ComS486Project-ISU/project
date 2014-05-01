<%@ page import="java.util.List" %>
<%@ page import="CananatorX.PrisumSolarCarState" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
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

</head>
<body>

<!-- HEADER AREA -->

<div class="navbar navbar-default navbar-static-top">
	<div class="navbar-header">
		<div class="navbar-brand">CANanator Web Interface</div>
	</div>
	<div align="right">
		<input type="checkbox" onchange='handleChange(this);' id="autoRefresh" /> Auto Refresh<br>
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
							<td></td>
						</tr>
						<tr>
							<td>Throttle Position</td>
							<td><c:out value="${telemetryData.throttlePositionPercent}" /></td>
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
							<td><c:out value="${telemetryData.stateOfCharge}" /></td>
						</tr>
						<tr>
							<td>Battery Capacity (<abbr title="Amp Hours">Ah</abbr>)</td>
							<td><c:out value="${telemetryData.maxCapacityAmpHours}" /></td>
						</tr>
						<tr>
							<td>High Module (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td><c:out value="${telemetryData.batteryModuleTempHigh}" /></td>
						</tr>
						<tr>
							<td>High Module (<abbr title="Volts">V</abbr>)</td>
							<td><c:out value="${telemetryData.batteryModuleVoltageHigh}" /></td>
						</tr>
						<tr>
							<td>Low Module (<abbr title="Volts">V</abbr>)</td>
							<td><c:out value="${telemetryData.batteryModuleVoltageLow}" /></td>
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
							<td><c:out value="${telemetryData.MPH}" /></td>
							<td><c:out value="${telemetryData.MPHrecent}" /></td>
							<td><c:out value="${telemetryData.MPHavg}" /></td>
							<td><c:out value="${telemetryData.MPHmax}" /></td>
							<td><c:out value="${telemetryData.MPHmin}" /></td>
						</tr>
						<tr>
							<td>Energy Consumption (<abbr title="Mile per Gallon Equivalent">MPGe</abbr>)</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td><abbr title="Power Tracker">MPPT</abbr> Efficiency</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Battery Pack Power (<abbr title="Watts">W</abbr>)</td>
							<td><fmt:formatNumber maxFractionDigits="3" type="number" value="${telemetryData.packPower}" /></td>
							<td><c:out value="${telemetryData.packPowerRecent}" /></td>
							<td><c:out value="${telemetryData.packPowerAvg}" /></td>
							<td><c:out value="${telemetryData.packPowerMax}" /></td>
							<td><c:out value="${telemetryData.packPowerMin}" /></td>
						</tr>
						<tr>
							<td>Solar Array Power (<abbr title="Watts">W</abbr>)</td>
							<td><c:out value="${telemetryData.arrayPower}" /></td>
							<td><c:out value="${telemetryData.arrayPowerRecent}" /></td>
							<td><c:out value="${telemetryData.arrayPowerAvg}" /></td>
							<td><c:out value="${telemetryData.arrayPowerMax}" /></td>
							<td><c:out value="${telemetryData.arrayPowerMin}" /></td>
						</tr>
						<tr>
							<td>Motor Power (<abbr title="Watts">W</abbr>)</td>
							<td><c:out value="${telemetryData.motorPower}" /></td>
							<td><c:out value="${telemetryData.motorPowerRecent}" /></td>
							<td><c:out value="${telemetryData.motorPowerAvg}" /></td>
							<td><c:out value="${telemetryData.motorPowerMax}" /></td>
							<td><c:out value="${telemetryData.motorPowerMin}" /></td>
						</tr>
						<tr>
							<td>Electronics Power (<abbr title="Watts">W</abbr>)</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>


<!-- REMOVED FOR DEMO						
						<tr>
							<td>Cockpit Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td><c:out value="${telemetryData.cockpitTemp}" /></td>
							<td><c:out value="${telemetryData.cockpitTempRecent}" /></td>
							<td><c:out value="${telemetryData.cockpitTempAvg}" /></td>
							<td><c:out value="${telemetryData.cockpitTempMax}" /></td>
							<td><c:out value="${telemetryData.cockpitTempMin}" /></td>
						</tr>
						<tr>
							<td>Motor Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Controller Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Baseplate Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td>Battery Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
						<tr>
							<td><abbr title="Power Tracker">MPPT</abbr> Temperature (<abbr title="Degrees Celcius">&deg;C</abbr>)</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
							<td>[Status]</td>
						</tr>
-->
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
							<td><c:out value="${telemetryData.packCurrent}" /></td>
							<td><c:out value="${telemetryData.packStatus}" /></td>
						</tr>
						<tr>
							<td>Array</td>
							<td><c:out value="${telemetryData.arrayCurrent}" /></td>
							<td><c:out value="${telemetryData.arrayStatus}" /></td>
						</tr>
						<tr>
							<td>Motor</td>
							<td><c:out value="${telemetryData.motorCurrent}" /></td>
							<td><c:out value="${telemetryData.motorBoardStatusString}" /></td>
							
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
							<td><fmt:formatNumber maxFractionDigits="3" type="number" value="${telemetryData.packVoltage}" /></td>
						</tr>
						<tr>
							<td>No Load Voltage (<abbr title="Volts">V</abbr>)</td>
							<td><fmt:formatNumber maxFractionDigits="3" type="number" value="${telemetryData.noLoadVoltage}" /></td>
					
						</tr>
						<tr>
							<td>Recent Voltage (<abbr title="Volts">V</abbr>)</td>
							<td><fmt:formatNumber maxFractionDigits="3" type="number" value="${telemetryData.packVoltageRecent}" /></td>
						
						</tr>
						<tr>
							<td>Module Range (<abbr title="Volts">V</abbr>)</td>
							<td><fmt:formatNumber maxFractionDigits="3" type="number" value="${telemetryData.batteryModuleVoltageRange}" /></td>
						
						</tr>
						<tr>
							<td><abbr title="Auxiliary">Aux.</abbr> Pack (<abbr title="Volts">V</abbr>)</td>
							<td><fmt:formatNumber maxFractionDigits="3" type="number" value="${telemetryData.auxPackVoltage}" /></td>
						</tr>
						<tr>
							<td><abbr title="Auxiliary">Aux.</abbr> Pack Level (<abbr title="Volts">V</abbr>)</td>
							<td>${telemetryData.auxPackLevel}</td>
						</tr>
						<tr>
							<td>12V Main Bus (<abbr title="Volts">V</abbr>)</td>
							<td><c:out value="${telemetryData.twelveVoltMainVoltage}" /></td>
						</tr>
						<tr>
							<td>12V <abbr title="Auxiliary">Aux.</abbr> Bus (<abbr title="Volts">V</abbr>)</td>
							<td><c:out value="${telemetryData.twelveVoltAuxVoltage}" /></td>
						</tr>
						<tr>
							<td>5V Bus (<abbr title="Volts">V</abbr>)</td>
							<td><c:out value="${telemetryData.fiveVoltVoltage}" /></td>
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
<div id="tabs">
	<ul class="nav nav-tabs">
		<li><a href="#bps" data-toggle="tab">Battery Protection (BPS)</a></li>
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
					<div class="col-xs-12 col-sm-12 col-md-10 col-lg-10">
						<div class="table" style="padding-top:20px">
							<table class="table table-striped table-condensed table-bordered">
								<thead>
									<tr>
										<th>Module Number</th>
										<th>Voltage</th>
										<th>Temp</th>
										<th>Errors</th>
									<!--
										<th>OVF</th>
										<th>OVW</th>
										<th>UVW</th>
										<th>UVF</th>
										<th>TRE</th>
										<th>OTF</th>
										<th>OTW</th>
										<th>UTW</th>
										<th>UTF</th>
										<th>DISC</th>
										<th>TRANGE</th> -->
									</tr>
								</thead>
								<tbody>
								  	<c:forEach var="moduleId" items="${telemetryData.batteryModuleIds}" varStatus="count">
										<tr>
											<td style="vertical-align:middle">Module <c:out value="${moduleId}"/></td>

											<!-- batteryModuleVoltages cell -->
											<td>
												<c:set var="batteryModuleVoltages" scope="session" value="${telemetryData.batteryModuleVoltages[count.index]}"/>
												<c:choose>
													<c:when test="${batteryModuleVoltages > 4.0}"><p class="list-group-item-success"><fmt:formatNumber maxFractionDigits="3" type="number" value="${telemetryData.batteryModuleVoltages[count.index]}" /></c:when>	<%-- when equal to a good fault code --%>
													<c:when test="${batteryModuleVoltages >= 3.5 && batteryModuleVoltages <= 40}"><p class="list-group-item-warning"><fmt:formatNumber maxFractionDigits="3" type="number" value="${telemetryData.batteryModuleVoltages[count.index]}" /></c:when>	<%-- when equal to a middle fault code --%>
													<c:when test="${batteryModuleVoltages < 3.5}"><p class="list-group-item-danger"><fmt:formatNumber maxFractionDigits="3" type="number" value="${telemetryData.batteryModuleVoltages[count.index]}" /></c:when>	<%-- when equal to a bad fault code --%>
													<c:otherwise>&nbsp;</c:otherwise>
												</c:choose>
											</td>

											<!-- batteryModuleTemperatures cell -->
											<td>
												<c:set var="batteryModuleTemperatures" scope="session" value="${telemetryData.batteryModuleTemperatures[count.index]}"/>
												<c:choose>
													<c:when test="${batteryModuleTemperatures >25 }"><p class="list-group-item-success"><c:out value="${telemetryData.batteryModuleTemperatures[count.index]}" /></c:when>	<%-- when equal to a good fault code --%>
													<c:when test="${batteryModuleTemperatures >= 35 && batteryModuleTemperatures <= 40}"><p class="list-group-item-warning"><c:out value="${telemetryData.batteryModuleTemperatures[count.index]}" /></c:when>	<%-- when equal to a middle fault code --%>
													<c:when test="${batteryModuleTemperatures > 45}"><p class="list-group-item-danger"><c:out value="${telemetryData.batteryModuleTemperatures[count.index]}" /></c:when>	<%-- when equal to a bad fault code --%>
													<c:otherwise>&nbsp;</c:otherwise>
												</c:choose>
											</td>

											<!-- Errors cell -->
											<td>
												<table>
													<tr>
														<c:set var="batteryModuleVoltageReadErrors" scope="session" value="${telemetryData.batteryModuleVoltageReadErrors[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleVoltageReadErrors == false}"></c:when>
															<c:otherwise><td class="list-group-item-danger">&nbsp;VRE&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleOverVoltFaults" scope="session" value="${telemetryData.batteryModuleOverVoltFaults[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleOverVoltFaults == false}"></c:when>
															<c:otherwise><td class="list-group-item-success">&nbsp;OVF&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleOverVoltWarnings" scope="session" value="${telemetryData.batteryModuleOverVoltWarnings[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleOverVoltWarnings == false}"></c:when>
															<c:otherwise><td class="list-group-item-warning">&nbsp;OVW&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleUnderVoltWarnings" scope="session" value="${telemetryData.batteryModuleUnderVoltWarnings[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleUnderVoltWarnings == false}"></c:when>
															<c:otherwise><td class="list-group-item-warning">&nbsp;UVW&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleUnderVoltFaults" scope="session" value="${telemetryData.batteryModuleUnderVoltFaults[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleUnderVoltFaults == false}"></c:when>
															<c:otherwise><td class="list-group-item-success">&nbsp;UVF&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleTempReadErrors" scope="session" value="${telemetryData.batteryModuleTempReadErrors[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleTempReadErrors == false}"></c:when>
															<c:otherwise><td class="list-group-item-danger">&nbsp;TRE&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleOverTempFaults" scope="session" value="${telemetryData.batteryModuleOverTempFaults[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleOverTempFaults == false}"></c:when>
															<c:otherwise><td class="list-group-item-success">&nbsp;OTF&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleOverTempWarnings" scope="session" value="${telemetryData.batteryModuleOverTempWarnings[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleOverTempWarnings == false}"></c:when>
															<c:otherwise><td class="list-group-item-warning">&nbsp;OTW&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleUnderTempWarnings" scope="session" value="${telemetryData.batteryModuleUnderTempWarnings[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleUnderTempWarnings == false}"></c:when>
															<c:otherwise><td class="list-group-item-warning">&nbsp;UTW&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleUnderTempFaults" scope="session" value="${telemetryData.batteryModuleUnderTempFaults[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleUnderTempFaults == false}"></c:when>
															<c:otherwise><td class="list-group-item-success">&nbsp;UTF&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleDisconnectedFaults" scope="session" value="${telemetryData.batteryModuleDisconnectedFaults[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleDisconnectedFaults == false}"></c:when>
															<c:otherwise><td class="list-group-item-success">&nbsp;MDF&nbsp;</td></c:otherwise>
														</c:choose>
														<c:set var="batteryModuleTempCalibrationRangeErrors" scope="session" value="${telemetryData.batteryModuleTempCalibrationRangeErrors[count.index]}"/>
														<c:choose>
															<c:when test="${batteryModuleTempCalibrationRangeErrors == false}"></c:when>
															<c:otherwise><td class="list-group-item-danger">&nbsp;TCRE&nbsp;</td></c:otherwise>
														</c:choose>
													</tr>
												</table>
											</td>
										</tr>
									</c:forEach>
								</tbody>
							</table>
						</div>
					</div>
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
 					<div align="center" style="padding-top:20px; padding-bottom:20px; height:550px; width:200px" >
	 					<div id="GoogleChart"> 					
					</div>
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

	<!-- Auto Refresh -->
		// Add tab hash to URL to preserve it on refresh
		<script type="text/javascript">
			$('#tabs').tabs({
			    beforeActivate: function (event, ui) {
			        window.location.hash = ui.newPanel.selector;
			    }
			});
			
			// If checkbox is selected, start auto-refresh
			var timeout;
			var cb = document.getElementById("autoRefresh");
			if (cb.checked)	{
				timeout = setTimeout(function(){
					window.location.reload(false);
				}, 5000);
			}
			
			// When checkbox is changed, start or cancel auto-refresh
			function handleChange(cb)	{
				if (cb.checked)	{
					window.location.reload(false);
				}
				else {
					clearTimeout(timeout);
				}
			}
			
		</script>
	
	<!-- Google Chart script stuff 
		 JSP OBJECT = graphData
		 DATA = graphData.getMphVsTime
		 		graphData.getPackCapacityVsTime
		 		graphData.getSystemVoltageVsTime
		 		graphData.getPackPowerVsTime
		 		
		 For google's chart, they use a 2d array to represent the graph
		 Columns indicate points for a single data stream. i.e. column time, etc.
		 Rows, for us, indicate a snapshot of values at a given time
		 
		 graphData.getX is a 1d array which we want to add as a column to the 2d graph array
		 graphData.getTime?
	-->
		<script src="https://www.google.com/jsapi" type="text/javascript"></script>
		
		<script type="text/javascript">
		google.load('visualization', '1', {packages: ['corechart']});
		</script>
		
		<script type="text/javascript">
		
		/*
		 * Function to create the data var for Google chart
		 */
		function constructData() {
			var retval;
			
			var mph = ${graphData.mphVsTime};
			var packCapacity = ${graphData.packCapacityVsTime}
			var systemVoltage = ${graphData.systemVoltageVsTime};
			var packPower = ${graphData.packPowerVsTime};
			var time = ${graphData.time};
			
			/*
			var time = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
			var mph = [0, 10, 20, 30, 40, 50, 60, 70, 80, 90];
			var packCapacity = [100, 90, 80, 70, 60, 50, 40, 30, 20, 10];
			var systemVoltage = [50, 50, 50, 50, 50, 50, 50, 50, 50, 50];
			var packPower = [25, 25, 25, 25, 25, 25, 25, 25, 25, 25];
			*/
			
			// Create the 2d array for the data
			retval = new Array(mph.length);
			for(var i = 0; i < retval.length; i++) {
				retval[i] = new Array(5);
				retval[i][0] = time[i];
				//retval[i][0] = "0";
				retval[i][1] = mph[i];
				retval[i][2] = packCapacity[i];
				retval[i][3] = systemVoltage[i];
				retval[i][4] = packPower[i];
			}
			
			return retval;
		}
		
		function drawVisualization() {
			// Create and populate the data table.
			var chartValues = constructData();
			var data = new google.visualization.DataTable();
			data.addColumn('string', 'Time');	// this probably needs to change to a number type
			data.addColumn('number', 'System Voltage vs. Time');
			data.addColumn('number', 'Pack Capacity vs. Time');
			data.addColumn('number', 'Pack Power vs. Time');
			data.addColumn('number', 'MPH vs. Time');
			
			for(var i = 0; i < chartValues.length; i++) {
				data.addRow(chartValues[i]);
			}
			
			/*
			data.addRow(["0", 17.7, 400, 98.5]);	// add code to update these values from the solar car
			data.addRow(["10", 20.6, 476, 98.1]);	// add code to update these values from the solar car
			data.addRow(["20", 21.1, 495, 97.4]);	// add code to update these values from the solar car
			data.addRow(["30", 19.4, 433, 97.0]);	// add code to update these values from the solar car
			*/
		 
			// Chart options
			var options = {
				//curveType: "function",
				vAxes: {
					0: { title: "Speed and Charge" },	// left axis
					1: { title: "Power" }	// right axis
				},
				hAxis: { title: "Time" },
				series:{
					0:{targetAxisIndex:0},
					1:{targetAxisIndex:1},
					2:{targetAxisIndex:0}
				},
 				'width': 800,
				'height': 500,
				tooltip: { isHtml: true },
				legend: { position: 'bottom' }
			
			};

			// Create and draw the visualization.
			new google.visualization.LineChart(document.getElementById('GoogleChart')).
			draw(data, options);
			

		}

		google.setOnLoadCallback(drawVisualization);
		</script>


	<!-- jqPlot stuff -->
	<!--<link href="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/jquery.jqplot.min.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/jquery.jqplot.min.js"></script>
	<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/plugins/jqplot.dateAxisRenderer.min.js"></script>
	<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/plugins/jqplot.highlighter.min.js"></script>
	<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/plugins/jqplot.cursor.min.js"></script>
	<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/plugins/jqplot.canvasTextRenderer.min.js"></script>
	<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jqPlot/1.0.8/plugins/jqplot.canvasAxisLabelRenderer.min.js"></script>


	<script type="text/javascript">
		$(document).ready(function () {
			var time = 500;	//refresh time (in millisec)
			var samples = 40;	//samples to draw
			var x = (new Date()).getTime();	// current time
			var dataZ = [];	//buffer of n samples
			var dataSpeed = [];
			var dataPower = [];
			var dataCharge = [];
			for (i = 0; i < samples; i++) {
				dataZ.push([x - (samples - 1 - i) * time, 0]);
				dataSpeed.push([x - (samples - 1 - i) * time, 0]);
				dataPower.push([x - (samples - 1 - i) * time, 0]);
				dataCharge.push([x - (samples - 1 - i) * time, 0]);
			}
	
			var options = {
				legend: {
					show:true,
					location: 'e',
					placement: "outsideGrid"
					//showLabels:true,
					//labels = ["Speed", "Power Consumption", "Charge Status"]
				},
				/*highlighter: { show: true },
				cursor: { show: false, tooltipLocation: 'ne' },*/
				axes: {
					xaxis: {
						numberTicks: 10,
						renderer: $.jqplot.DateAxisRenderer,
						tickOptions: { formatString: '%H:%M:%S' },
						min: dataZ[0][0],
						max: dataZ[dataZ.length - 1][0],
						label: 'Local Time',
						labelRenderer: $.jqplot.CanvasAxisLabelRenderer
					},
					yaxis: {
						min: 0,
						autoscale: true,
						//max: 10, // reset to required maximum scale
						numberTicks: 6,
						tickOptions: { formatString: '%.1f'	},
						label: 'Speed and Charge',
						labelRenderer: $.jqplot.CanvasAxisLabelRenderer
					},
					y2axis: {
						min: 0,
						autoscale: true,
						//max: 10, // reset to required maximum scale
						numberTicks: 6,
						tickOptions: { formatString: '%.1f'	},
						label: 'Power',
						labelRenderer: $.jqplot.CanvasAxisLabelRenderer
					}
				},
				//seriesDefaults: { rendererOptions: { smooth: false } }, // shows lines between points as curved or linear
				series: [
					{ label: 'Speed', yaxis:'yaxis'},
					{ label: 'Power Consumption', yaxis:'y2axis' },
					{ label: 'Charge Status', yaxis:'yaxis' },
				]
			};
			
			var plot1 = $.jqplot('jqPlotLive', [dataSpeed, dataPower, dataCharge], options);
	
			$('button').click(function () {
				doUpdate();
				$(this).hide();
			});
    
			function doUpdate() {
				if (dataZ.length > samples - 1) {
					dataZ.shift();
					dataSpeed.shift();
					dataPower.shift();
					dataCharge.shift();
				}

				var yZ = 0;
				var ySpeed = Math.random();					// y values for speed -- replace with code to bean ?
				var yPower = Math.random()/Math.random()/Math.random()+100;	// y values for power -- replace with code to bean ?
				var yCharge = Math.random()*Math.random();	// y values for charge -- replace with code to bean ?

				var x = (new Date()).getTime();

				dataZ.push([x, yZ]);
				dataSpeed.push([x, ySpeed]);
				dataPower.push([x, yPower]);
				dataCharge.push([x, yCharge]);

				if (plot1) {
					plot1.destroy();
				}
				
				//plot1.series[0].dataZ = dataZ;
				plot1.series[0].dataSpeed = dataSpeed;
				plot1.series[1].dataPower = dataPower;
				plot1.series[2].dataCharge = dataCharge;

				// the problem is that now the values ​​on the y ticks are no longer static
				// and change with each update, and then change the underlying logic
				// need to adjust the values ​​in options.

				options.axes.xaxis.min = dataZ[0][0];
				options.axes.xaxis.max = dataZ[dataZ.length - 1][0];
				plot1 = $.jqplot('jqPlotLive', [dataSpeed, dataPower, dataCharge], options);
				setTimeout(doUpdate, time);
			}	
		});
	</script>-->

</body>
</html>
