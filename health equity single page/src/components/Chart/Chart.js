import React from "react";
import ChartBar from "./ChartBar";
import "./Chart.css";

const Chart = (props) => {
  const valueArray = props.dataPoints.map((datapoint) => datapoint.value);
  const totalMaximun = Math.max(...valueArray);

  return (
    <div className="chart">
      {props.dataPoints.map((dataPoint) => (
        <ChartBar
          key={dataPoint.label}
          label={dataPoint.label}
          maxValue={totalMaximun}
          value={dataPoint.value}
        />
      ))}
    </div>
  );
};

export default Chart;
