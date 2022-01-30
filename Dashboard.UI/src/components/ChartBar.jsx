import React from "react";
import { Chart } from "react-google-charts";

const ChartBar = ({ lifes }) => {

    const data = [
        ["Id", "Active Days"]
    ];

    lifes.map(l => data.push([l.userId.toString(), l.lifeDays]))

    const options = {
        title: "Users life, in days",
        legend: { position: "none" },
        histogram: {
            bucketSize: 1,
        },
        hAxis: {
            title: "Active days"
        },
        vAxis: {
            title: "Users",
        },
    };

    return(
        <div>
        <Chart
            chartType="Histogram"
            width="100%"
            height="400px"
            data={data}
            options={options}
        />
        </div >
    )
}

export default ChartBar;