import React, { Component } from "react";
import {
  Row,
  Col,
  Card,
  CardBody,
  CardFooter,
  ListGroup,
  ListGroupItem,
  CardHeader
} from "reactstrap";
import { Link } from "react-router-dom";
import BranchForm from "./../components/branchForm";
import MyModal from "./../components/common/modal.jsx";

class BranchDetails extends Component {
  state = {
    branchFormModal: false
  };

  branchFormToggle = async () => {
    this.setState({ branchFormModal: !this.state.branchFormModal });
  };
  render() {
    const { branch } = this.props.location.state;
    return (
      <div className="content">
        <Row>
          <h2>{branch.name} Branch </h2>
          <MyModal
            title="Branch Form"
            buttonLabel="Edit"
            color="warning"
            icon="fas fa-pen"
            content={
              <BranchForm branchId={branch.id} toggle={this.branchFormToggle} />
            }
            modal={this.state.branchFormModal}
            toggle={this.branchFormToggle}
          />
        </Row>
        <Row>
          <Col lg="4" md="6" sm="6">
            <Card className="card-stats">
              <CardHeader>Employees </CardHeader>
              <CardBody>
                <ListGroup>
                  {branch.employees.map(employee => (
                    <ListGroupItem tag="button" action key={employee.id}>
                      <Link
                        to={{
                          pathname: `/admin/employees/${employee.id}`,
                          state: { employee }
                        }}
                      >
                        {employee.firstName}
                      </Link>
                    </ListGroupItem>
                  ))}
                </ListGroup>
              </CardBody>
              <CardFooter>
                <hr />
                <div className="stats"></div>
              </CardFooter>
            </Card>
          </Col>
          <Col lg="4" md="6" sm="6">
            <Card className="card-stats">
              <CardHeader>Shops</CardHeader>
              <CardBody>
                <ListGroup>
                  {branch.shops.map(shop => (
                    <ListGroupItem tag="button" action key={shop.id}>
                      <Link
                        to={{
                          pathname: `/admin/shops/${shop.id}`,
                          state: { shop }
                        }}
                      >
                        {shop.name}
                      </Link>
                    </ListGroupItem>
                  ))}
                </ListGroup>
              </CardBody>
              <CardFooter>
                <hr />
                <div className="stats"></div>
              </CardFooter>
            </Card>
          </Col>
          <Col lg="4" md="6" sm="6">
            <Card className="card-stats">
              <CardHeader>Simcards</CardHeader>
              <CardBody>
                <ListGroup>
                  {branch.simcards.map(simcard => (
                    <ListGroupItem tag="button" action key={simcard.id}>
                      <Link
                        to={{
                          pathname: `/admin/simcards/${simcard.id}`,
                          state: { simcard }
                        }}
                      >
                        {simcard.phoneNumber}
                      </Link>
                    </ListGroupItem>
                  ))}
                </ListGroup>
              </CardBody>
              <CardFooter>
                <hr />
                <div className="stats"></div>
              </CardFooter>
            </Card>
          </Col>
        </Row>
      </div>
    );
  }
}

export default BranchDetails;
