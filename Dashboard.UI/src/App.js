import React, { useState } from 'react';
import ShowChart from './components/ShowChart';
import MyButton from './components/UI/button/MyButton';
import UsersTable from './components/UsersTable';
import './styles/App.css';

function App() {
    const [canCalculate , setCanCalculate] = useState(false);

    const handleCalculate  = () => {
        setCanCalculate ({canCalculate : true});
    }

    return (
        <div className="App">
            <UsersTable/>
            <MyButton onClick={handleCalculate}>Calculate</MyButton>
            <ShowChart canCalculate ={canCalculate }/>
        </div>
    );
}

export default App;