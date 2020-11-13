import React, { Component } from "react";
// import auth from "../services/authService";
import { Link } from "react-router-dom";
import Table from "./common/table";
// import Like from "./common/like";

class ShopsTable extends Component {
  branches = this.props.branches;

  columns = [
    {
      path: "name",
      label: "Location",
      content: shop => (
        <Link
          to={{
            pathname: `/admin/shops/${shop.id}`,
            state: {
              shop,
              branches: this.props.branches,
              employees: this.props.employees
            }
          }}
        >
          {shop.name}
        </Link>
      )
    },
    { path: "employee.firstName", label: "Assigned Employee" },
    {
      key: "delete",
      content: shop => (
        <button
          onClick={() => this.props.onDelete(shop)}
          className="btn btn-danger btn-sm"
        >
          Delete
        </button>
      )
    }
  ];

  componentDidMount() {}

  render() {
    const { shops, onSort, sortColumn } = this.props;

    return (
      <Table
        columns={this.columns}
        data={shops}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default ShopsTable;
