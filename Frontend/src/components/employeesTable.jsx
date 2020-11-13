import React, { Component } from "react";
// import auth from "../services/authService";
import { Link } from "react-router-dom";
import Table from "./common/table";
// import Like from "./common/like";

class EmployeesTable extends Component {
  branches = [];
  branches = this.props.branches;

  columns = [
    {
      path: "firstName",
      label: "First Name",
      content: employee => (
        <Link
          to={{
            pathname: `/admin/employees/${employee.id}`,
            state: { employee, branches: this.props.branches }
          }}
        >
          {employee.lastName}, {employee.firstName}
        </Link>
      )
    },
    {
      key: "delete",
      content: employee => (
        <button
          onClick={() => this.props.onDelete(employee)}
          className="btn btn-danger btn-sm"
        >
          Delete
        </button>
      )
    }
  ];

  componentDidMount() {
    console.log(this.branches);
  }

  render() {
    const { employees, onSort, sortColumn } = this.props;

    return (
      <Table
        columns={this.columns}
        data={employees}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default EmployeesTable;
