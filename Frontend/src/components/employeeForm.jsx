import React from "react";

import Joi from "joi-browser";
import Form from "./common/form";
import { getEmployee, saveEmployee } from "../services/employeeService";

class EmployeeForm extends Form {
  state = {
    data: {
      branchId: "",
      firstName: "",
      lastName: ""
    },
    branches: [],
    errors: {}
  };

  schema = {
    id: Joi.string(),
    branchId: Joi.string()
      .required()
      .label("Branch"),
    firstName: Joi.string()
      .required()
      .label("Name"),
    lastName: Joi.string()
      .required()
      .label("Name")
  };

  async populateEmployee() {
    try {
      const employeeId = this.props.employeeId;
      if (employeeId === "new") return;

      const { data: employee } = await getEmployee(employeeId);
      this.setState({ data: this.mapToViewModel(employee) });
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        this.props.history.replace("/not-found");
    }
  }

  populateBranches = async () => {
    await this.setState({ branches: this.props.branches });
  };

  async componentDidMount() {
    await this.populateBranches();
    await this.populateEmployee();
  }

  mapToViewModel(employee) {
    return {
      id: employee.id,
      branchId: employee.branchId,
      firstName: employee.firstName,
      lastName: employee.lastName
    };
  }

  doSubmit = async () => {
    await saveEmployee(this.state.data);
    this.props.toggle();
  };

  render() {
    return (
      <div>
        <form onSubmit={this.handleSubmit}>
          {this.renderSelect("branchId", "Branch", this.state.branches)}

          {this.renderInput("firstName", "First Name")}
          {this.renderInput("lastName", "Last Name")}
          {this.renderButton("Save")}
        </form>
      </div>
    );
  }
}

export default EmployeeForm;
