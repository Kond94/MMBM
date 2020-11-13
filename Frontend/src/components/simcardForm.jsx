import React from "react";

import Joi from "joi-browser";
import Form from "./common/form";
import { getSimcard, saveSimcard } from "../services/simcardService";

class SimcardForm extends Form {
  state = {
    data: {
      branchId: "",
      phoneNumber: ""
    },
    branches: [],
    employees: [],
    errors: {}
  };

  schema = {
    id: Joi.string(),
    branchId: Joi.string()
      .required()
      .label("Branch"),
    employeeId: Joi.string().label("Assigned Employee"),
    phoneNumber: Joi.string()
      .required()
      .label("Phone Number")
  };

  async populateSimcard() {
    try {
      const simcardId = this.props.simcardId;
      if (simcardId === "new") return;

      const { data: simcard } = await getSimcard(simcardId);
      this.setState({ data: this.mapToViewModel(simcard) });
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        this.props.history.replace("/not-found");
    }
  }

  populateBranches = async () => {
    await this.setState({ branches: this.props.branches });
  };

  populateEmployees = async () => {
    let employees = this.props.employees.map(e => {
      e.name = e.firstName;
      return e;
    });

    employees =
      this.state.data.branchId === ""
        ? []
        : // eslint-disable-next-line
          this.state.branches.find(b => b.id == this.state.data.branchId)
            .employees;
    await this.setState({ employees });
  };

  async componentDidMount() {
    await this.populateBranches();
    await this.populateEmployees();
    await this.populateSimcard();
  }

  mapToViewModel(simcard) {
    return {
      id: simcard.id,
      branchId: simcard.branchId,
      phoneNumber: simcard.phoneNumber
    };
  }

  doSubmit = async () => {
    await saveSimcard(this.state.data);
    this.props.toggle();
  };

  render() {
    return (
      <div>
        <form onSubmit={this.handleSubmit}>
          {this.renderSelect("branchId", "Branch", this.state.branches)}

          {this.renderInput("phoneNumber", "Phone Number", "number")}

          {this.renderSelect(
            "employeeId",
            "Assigned Employee",
            this.state.employees
          )}

          {this.renderButton("Save")}
        </form>
      </div>
    );
  }
}

export default SimcardForm;
