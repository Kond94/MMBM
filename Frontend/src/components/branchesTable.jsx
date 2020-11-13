import React, { Component } from "react";
// import auth from "../services/authService";
import { Link } from "react-router-dom";
import Table from "./common/table";
// import Like from "./common/like";

class BranchesTable extends Component {
  columns = [
    {
      path: "name",
      label: "Location",
      content: branch => (
        <Link
          to={{ pathname: `/admin/branches/${branch.id}`, state: { branch } }}
        >
          {branch.name}
        </Link>
      )
    },
    {
      key: "delete",
      content: branch => (
        <button
          onClick={() => this.props.onDelete(branch)}
          className="btn btn-danger btn-sm"
        >
          Delete
        </button>
      )
    }
  ];

  componentDidMount() {}

  render() {
    const { branches, onSort, sortColumn } = this.props;

    return (
      <Table
        columns={this.columns}
        data={branches}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default BranchesTable;
