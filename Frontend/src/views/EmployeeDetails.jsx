import React, { Component } from "react";
import { Row } from "reactstrap";
import EmployeeForm from "./../components/employeeForm";
import MyModal from "./../components/common/modal.jsx";

class EmployeeDetails extends Component {
  state = {
    employeeFormModal: false,
    branches: []
  };

  employeeFormToggle = async () => {
    this.setState({ employeeFormModal: !this.state.employeeFormModal });
  };
  render() {
    const { employee } = this.props.location.state;

    return (
      <div className="content">
        <Row>
          <h2>
            {employee.firstName} {employee.lastName}
          </h2>
          <MyModal
            title="Employee Form"
            buttonLabel="Edit"
            color="warning"
            icon="fas fa-pen"
            content={
              <EmployeeForm
                employeeId={employee.id}
                branches={this.state.branches}
                toggle={this.employeeFormToggle}
              />
            }
            modal={this.state.employeeFormModal}
            toggle={this.employeeFormToggle}
          />
        </Row>
      </div>
    );
  }
}

export default EmployeeDetails;
