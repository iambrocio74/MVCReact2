import { useEffect, useState } from 'react';
import './App.css';
import React from "react";
import { Container, Row, Col, Card, CardHeader, CardBody, CardFooter, Button } from "reactstrap"
import Tarjeta from './components/Tarjeta.jsx';
import "bootstrap/dist/css/bootstrap.min.css"


const App = () => {
    const [empleados, setEmpleados] = useState([])

    /**
     * servicios API
     */
    const mostrarEmpleados = async () => {
        const response = await fetch("api/empleados/lista")

        if (response.ok){
            const data = await response.json()

            setEmpleados(data)
        }
    }

    useEffect(() => {
        mostrarEmpleados()
    }, [])

    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Lista de Empleados</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success">Nuevo Empleado</Button>
                            <hr></hr>
                            <Tarjeta
                                data={ empleados }
                            />
                        </CardBody>
                    </Card>
                </Col>
            </Row>
        </Container>
    )
}

export default App

//function App() {
//    //const [empleados, setEmpleados, forecasts, setForecasts] = useState();
//    const [empleados, setEmpleados] = useState();

//    useEffect(() => {
//        //populateWeatherData();
//        populateEmpleadosData();
//    }, []);

//    //const contents = forecasts === undefined
//    //    ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
//    //    : <table className="table table-striped" aria-labelledby="tabelLabel">
//    //        <thead>
//    //            <tr>
//    //                <th>Date</th>
//    //                <th>Temp. (C)</th>
//    //                <th>Temp. (F)</th>
//    //                <th>Summary</th>
//    //            </tr>
//    //        </thead>
//    //        <tbody>
//    //            {forecasts.map(forecast =>
//    //                <tr key={forecast.date}>
//    //                    <td>{forecast.date}</td>
//    //                    <td>{forecast.temperatureC}</td>
//    //                    <td>{forecast.temperatureF}</td>
//    //                    <td>{forecast.summary}</td>
//    //                </tr>
//    //            )}
//    //        </tbody>
//    //    </table>;

//    const contentsE = empleados === undefined
//        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
//        : <table className="table table-striped" aria-labelledby="tabelLabel">
//            <thead>
//                <tr>
//                    <th>Nombre</th>
//                    <th>Correo</th>
//                    <th>Direccion</th>
//                    <th>Telefono</th>
//                </tr>
//            </thead>
//            <tbody>
//                {empleados.map(item =>
//                    <tr key={item.idEmpleado}>
//                        <td>{item.nombre}</td>
//                        <td>{item.correo}</td>
//                        <td>{item.direccion}</td>
//                        <td>{item.telefono}</td>
//                    </tr>
//                )}
//            </tbody>
//        </table>;

//    return (
//        <div>
//            <h1 id="tabelLabel">Weather forecast and empleados</h1>
//            <p>This component demonstrates fetching data from the server.</p>
//            {/*{contents, contentsE}*/}
//            {contentsE}
//        </div>
//    );
    
//    //async function populateWeatherData() {
//    //    const response = await fetch('weatherforecast');
//    //    const data = await response.json();
//    //    setForecasts(data);
//    //}

//    async function populateEmpleadosData() {
//        const response = await fetch('empleados');
//        const data = await response.json();
//        setEmpleados(data);
//    }
//}

/*export default App;*/