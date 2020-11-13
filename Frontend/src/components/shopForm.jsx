import React from "react";

import Joi from "joi-browser";
import Form from "./common/form";
import { getShop, saveShop } from "../services/shopService";

class ShopForm extends Form {
  state = {
    data: {
      branchId: "",
      name: ""
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
    name: Joi.string()
      .required()
      .label("Name")
  };

  async populateShop() {
    try {
      const shopId = this.props.shopId;
      if (shopId === "new") return;

      const { data: shop } = await getShop(shopId);
      this.setState({ data: this.mapToViewModel(shop) });
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
    await this.populateShop();
  }

  mapToViewModel(shop) {
    return {
      id: shop.id,
      branchId: shop.branchId,
      name: shop.name
    };
  }

  doSubmit = async () => {
    await saveShop(this.state.data);
    this.props.toggle();
  };

  render() {
    return (
      <div>
        <form onSubmit={this.handleSubmit}>
          {this.renderSelect("branchId", "Branch", this.state.branches)}

          {this.renderInput("name", "Name/Location")}

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

export default ShopForm;
