import React, { Component } from "react";
// import auth from "../services/authService";
import { Link } from "react-router-dom";
import Table from "./common/table";
// import Like from "./common/like";

class SimcardsTable extends Component {
  branches = [];
  employees = [];
  branches = this.props.branches;
  employees = this.props.employees;

  columns = [
    {
      path: "phoneNumber",
      label: "Phone Number",
      content: simcard => (
        <Link
          to={{
            pathname: `/admin/simcards/${simcard.id}`,
            state: {
              simcard,
              branches: this.props.branches,
              employees: this.props.employees
            }
          }}
        >
          {simcard.phoneNumber}
        </Link>
      )
    },
    { path: "employee.firstName", label: "Assigned Employee" },
    {
      key: "delete",
      content: simcard => (
        <button
          onClick={() => this.props.onDelete(simcard)}
          className="btn btn-danger btn-sm"
        >
          Delete
        </button>
      )
    }
  ];

  componentDidMount() {}

  render() {
    const { simcards, onSort, sortColumn } = this.props;
    return (
      <Table
        columns={this.columns}
        data={simcards}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default SimcardsTable;
