import { Table } from "reactstrap"
import "bootstrap/dist/css/bootstrap.min.css"

const Tarjeta = ({data }) => {
    return (
        <Table>
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Correo</th>
                    <th>Dirección</th>
                    <th>Teléfono</th>
                </tr>
            </thead>
            <tbody>
                {
                    (data.length < 1) ? (
                        <tr>Sin Registros</tr>
                    ) : (
                        data.map((item) => (
                            <tr key={item.IdEmpleado}>
                                <td>{item.Nombre}</td>
                                <td>{item.Correo}</td>
                                <td>{item.Direccion}</td>
                                <td>{item.Telefono}</td>
                                <td>
                                    <Button color="primary" size="sm" className="me-2">Editar</Button>
                                    <Button color="danger" size="sm" className="me-2">Eliminar</Button>
                                </td>
                            </tr>
                        ))
                    )
                }
            </tbody>
        </Table>
    )
}

export default Tarjeta