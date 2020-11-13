import React from "react";

import Joi from "joi-browser";
import Form from "./common/form";
import { getBranch, saveBranch } from "../services/branchService";

class BranchForm extends Form {
  state = {
    data: {
      name: ""
    },
    errors: {}
  };

  schema = {
    id: Joi.string(),
    name: Joi.string()
      .required()
      .label("Name")
  };

  async populateBranch() {
    try {
      const branchId = this.props.branchId;
      if (branchId === "new") return;

      const { data: branch } = await getBranch(branchId);
      this.setState({ data: this.mapToViewModel(branch) });
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        this.props.history.replace("/not-found");
    }
  }

  async componentDidMount() {
    await this.populateBranch();
  }

  mapToViewModel(branch) {
    return {
      id: branch.id,
      name: branch.name
    };
  }

  doSubmit = async () => {
    await saveBranch(this.state.data);
    this.props.toggle();
  };

  render() {
    return (
      <div>
        <form onSubmit={this.handleSubmit}>
          {this.renderInput("name", "Name/Location")}
          {this.renderButton("Save")}
        </form>
      </div>
    );
  }
}

export default BranchForm;
