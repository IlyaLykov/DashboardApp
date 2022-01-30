import React, { useEffect, useState } from "react";
import UserService from "../API/UserService";
import ChartBar from "./ChartBar";

const ShowChart = ({ canCalculate }) => {
    const [lifes, setLifes] = useState([{ id: '', lifeDays: '' }]);
    const [rollingRetention, setRollingRetention] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const histogramData = await UserService.getHistogramData();
            setLifes(histogramData);
        }
        fetchData();
    }, [canCalculate]);

    useEffect(() => {
        const fetchRR = async () => {
            const rollingRetention = await UserService.getRollingRetention();
            setRollingRetention(rollingRetention);
        }
        fetchRR();
    }, [canCalculate]);

    return (
        <div>
            {canCalculate &&
                <p>Rolling Retention 7 day: {rollingRetention}%</p>
            }
            {canCalculate &&
                <ChartBar lifes={lifes} />
            }
        </div>
    );
}

export default ShowChart;