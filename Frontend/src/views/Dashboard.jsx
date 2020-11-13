import React from "react";
// react plugin used to create charts
// import { Line, Pie } from "react-chartjs-2";
// reactstrap components
import {
  Card,
  // CardHeader,
  CardBody,
  CardFooter,
  CardTitle,
  Row,
  Col,
  Spinner
} from "reactstrap";
// core components
// import {
//   dashboard24HoursPerformanceChart,
//   dashboardEmailStatisticsChart,
//   dashboardNASDAQChart
// } from "variables/charts.jsx";
import confirm from "reactstrap-confirm";

import MyModal from "components/common/modal.jsx";

import { getBranches, deleteBranch } from "../services/branchService";
import BranchForm from "components/branchForm";
import BranchesTable from "../components/branchesTable";
import ShopsTable from "./../components/shopsTable";
import ShopForm from "./../components/shopForm";
import { deleteShop } from "services/shopService";
import EmployeeForm from "./../components/employeeForm";
import { deleteEmployee } from "services/employeeService";
import { deleteSimcard } from "services/simcardService";
import EmployeesTable from "./../components/employeesTable";
import SimcardForm from "./../components/simcardForm";
import SimcardsTable from "./../components/simcardsTable";

class Dashboard extends React.Component {
  state = {
    branches: [],
    employees: [],
    shops: [],
    simcards: [],
    currentPage: 1,
    pageSize: 4,
    searchQuery: "",
    selectedGenre: null,
    sortColumn: { path: "name", order: "asc" },
    branchFormModal: false,
    branchTableModal: false,
    shopFormModal: false,
    shopTableModal: false,
    employeeFormModal: false,
    employeeTableModal: false,
    simcardFormModal: false,
    simcardTableModal: false,
    isLoading: true
  };

  branchFormToggle = async () => {
    if (this.state.branchFormModal === true) await this.refreshData();

    this.setState({ branchFormModal: !this.state.branchFormModal });
  };

  branchTableToggle = () => {
    this.setState({ branchTableModal: !this.state.branchTableModal });
  };

  shopFormToggle = async () => {
    if (this.state.shopFormModal === true) await this.refreshData();
    this.setState({ shopFormModal: !this.state.shopFormModal });
  };

  shopTableToggle = async () => {
    this.setState({ shopTableModal: !this.state.shopTableModal });
  };

  employeeFormToggle = async () => {
    if (this.state.employeeFormModal === true) await this.refreshData();
    this.setState({ employeeFormModal: !this.state.employeeFormModal });
  };

  employeeTableToggle = async () => {
    this.setState({ employeeTableModal: !this.state.employeeTableModal });
  };

  simcardFormToggle = async () => {
    if (this.state.simcardFormModal === true) await this.refreshData();
    this.setState({ simcardFormModal: !this.state.simcardFormModal });
  };

  simcardTableToggle = async () => {
    this.setState({ simcardTableModal: !this.state.simcardTableModal });
  };

  refreshData = async () => {
    this.setState({ isLoading: true });
    const { data: branches } = await getBranches();

    let employees = [].concat.apply(
      [],
      branches.map(b => b.employees)
    );

    employees = employees.map(e => {
      e.name = e.firstName;
      return e;
    });
    const shops = [].concat.apply(
      [],
      branches.map(b => b.shops)
    );

    const simcards = [].concat.apply(
      [],
      branches.map(b => b.simcards)
    );
    this.setState({ branches, employees, simcards, shops });
    this.setState({ isLoading: false });
  };

  async componentDidMount() {
    await this.refreshData();
  }

  confirm = message => {
    return confirm({
      title: (
        <div>
          <strong>Confirm Delete</strong>!
        </div>
      ),
      message:
        "Deleting this " +
        message +
        " will also remove all related data. Are you sure you want to do this?",
      confirmText: "Yes",
      confirmColor: "danger",
      cancelColor: "link text-primary"
    });
  };

  handleBranchDelete = async branch => {
    let result = await this.confirm("Branch");

    if (result === false) return;

    const originalBranches = this.state.branches;
    const branches = originalBranches.filter(m => m.id !== branch.id);
    this.setState({ branches });

    try {
      await deleteBranch(branch.id);
      await this.refreshData();
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        // toast.error("This branch has already been deleted.");

        this.setState({ branches: originalBranches });
    }
  };

  handleShopDelete = async shop => {
    let result = await this.confirm("Shop");

    if (result === false) return;

    const originalShops = this.state.shops;
    const shops = originalShops.filter(m => m.id !== shop.id);
    this.setState({ shops });

    try {
      await deleteShop(shop.id);
      await this.refreshData();
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        // toast.error("This branch has already been deleted.");

        this.setState({ shops: originalShops });
    }
  };

  handleEmployeeDelete = async employee => {
    let result = await this.confirm("Employee");

    if (result === false) return;

    const originalEmployees = this.state.employees;
    const employees = originalEmployees.filter(m => m.id !== employee.id);
    this.setState({ employees });

    try {
      await deleteEmployee(employee.id);
      await this.refreshData();
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        // toast.error("This branch has already been deleted.");

        this.setState({ employees: originalEmployees });
    }
  };

  handleSimcardDelete = async simcard => {
    let result = await this.confirm("Simcard");

    if (result === false) return;

    const originalSimcards = this.state.simcards;
    const simcards = originalSimcards.filter(m => m.id !== simcard.id);
    this.setState({ simcards });

    try {
      await deleteSimcard(simcard.id);
      await this.refreshData();
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        // toast.error("This branch has already been deleted.");

        this.setState({ simcards: originalSimcards });
    }
  };

  handlePageChange = page => {
    this.setState({ currentPage: page });
  };

  handleSort = sortColumn => {
    this.setState({ sortColumn });
  };

  render() {
    const {
      // pageSize,
      //  currentPage,
      sortColumn
      // searchQuery
    } = this.state;
    return (
      <>
        <div className="content">
          <Row>
            <Col lg="3" md="6" sm="6">
              <Card className="card-stats">
                <CardBody>
                  <Row>
                    <Col md="4" xs="5">
                      <div className="icon-big text-center icon-warning">
                        <i className="fas fa-building text-warning" />
                      </div>
                    </Col>
                    <Col md="8" xs="7">
                      <div className="numbers">
                        <p className="card-category">Branches</p>
                        {this.state.isLoading ? (
                          <Spinner color="primary" />
                        ) : (
                          <CardTitle tag="p">
                            {this.state.branches.length}
                          </CardTitle>
                        )}
                        <p />
                      </div>
                    </Col>
                  </Row>
                </CardBody>
                <CardFooter>
                  <hr />
                  {this.state.isLoading ? (
                    <></>
                  ) : (
                    <div className="stats">
                      <span className="pull-left">
                        <MyModal
                          title="Branch Form"
                          buttonLabel="Add"
                          color="success"
                          icon="fas fa-plus"
                          content={
                            <BranchForm toggle={this.branchFormToggle} />
                          }
                          modal={this.state.branchFormModal}
                          toggle={this.branchFormToggle}
                        />
                      </span>
                      <span className="pull-right">
                        <MyModal
                          toggle={this.branchTableToggle}
                          modal={this.state.branchTableModal}
                          title="Branches"
                          buttonLabel="View"
                          color="warning"
                          icon="fas fa-pen"
                          content={
                            <BranchesTable
                              branches={this.state.branches}
                              sortColumn={sortColumn}
                              onDelete={this.handleBranchDelete}
                              onSort={this.handleSort}
                            />
                          }
                        />
                      </span>
                    </div>
                  )}
                </CardFooter>
              </Card>
            </Col>
            <Col lg="3" md="6" sm="6">
              <Card className="card-stats">
                <CardBody>
                  <Row>
                    <Col md="4" xs="5">
                      <div className="icon-big text-center icon-warning">
                        <i className="fas fa-store text-success" />
                      </div>
                    </Col>
                    <Col md="8" xs="7">
                      <div className="numbers">
                        <p className="card-category">Shops</p>
                        {this.state.isLoading ? (
                          <Spinner color="primary" />
                        ) : (
                          <CardTitle tag="p">
                            {this.state.shops.length}
                          </CardTitle>
                        )}
                      </div>
                    </Col>
                  </Row>
                </CardBody>
                <CardFooter>
                  <hr />
                  {this.state.isLoading ? (
                    <></>
                  ) : (
                    <div className="stats">
                      <span className="pull-left">
                        <MyModal
                          title="Shop Form"
                          buttonLabel="Add"
                          color="success"
                          icon="fas fa-plus"
                          content={
                            <ShopForm
                              shopId="new"
                              branches={this.state.branches}
                              employees={this.state.employees}
                              toggle={this.shopFormToggle}
                            />
                          }
                          modal={this.state.shopFormModal}
                          toggle={this.shopFormToggle}
                        />
                      </span>
                      <span className="pull-right">
                        <MyModal
                          toggle={this.shopTableToggle}
                          modal={this.state.shopTableModal}
                          title="Shops"
                          buttonLabel="View"
                          color="warning"
                          icon="fas fa-pen"
                          content={
                            <ShopsTable
                              shops={this.state.shops}
                              branches={this.state.branches}
                              employees={this.state.employees}
                              sortColumn={sortColumn}
                              onDelete={this.handleShopDelete}
                              onSort={this.handleSort}
                            />
                          }
                        />
                      </span>
                    </div>
                  )}
                </CardFooter>
              </Card>
            </Col>
            <Col lg="3" md="6" sm="6">
              <Card className="card-stats">
                <CardBody>
                  <Row>
                    <Col md="4" xs="5">
                      <div className="icon-big text-center icon-warning">
                        <i className="fas fa-users text-danger" />
                      </div>
                    </Col>
                    <Col md="8" xs="7">
                      <div className="numbers">
                        <p className="card-category">Employees</p>
                        {this.state.isLoading ? (
                          <Spinner color="primary" />
                        ) : (
                          <CardTitle tag="p">
                            {this.state.employees.length}
                          </CardTitle>
                        )}
                      </div>
                    </Col>
                  </Row>
                </CardBody>
                <CardFooter>
                  <hr />
                  {this.state.isLoading ? (
                    <></>
                  ) : (
                    <div className="stats">
                      <span className="pull-left">
                        <MyModal
                          title="Employee Form"
                          buttonLabel="Add"
                          color="success"
                          icon="fas fa-plus"
                          content={
                            <EmployeeForm
                              employeeId="new"
                              branches={this.state.branches}
                              toggle={this.employeeFormToggle}
                            />
                          }
                          modal={this.state.employeeFormModal}
                          toggle={this.employeeFormToggle}
                        />
                      </span>
                      <span className="pull-right">
                        <MyModal
                          toggle={this.employeeTableToggle}
                          modal={this.state.employeeTableModal}
                          title="Employees"
                          buttonLabel="View"
                          color="warning"
                          icon="fas fa-pen"
                          content={
                            <EmployeesTable
                              employees={this.state.employees}
                              branches={this.state.branches}
                              sortColumn={sortColumn}
                              onDelete={this.handleEmployeeDelete}
                              onSort={this.handleSort}
                            />
                          }
                        />
                      </span>
                    </div>
                  )}
                </CardFooter>
              </Card>
            </Col>
            <Col lg="3" md="6" sm="6">
              <Card className="card-stats">
                <CardBody>
                  <Row>
                    <Col md="4" xs="5">
                      <div className="icon-big text-center icon-warning">
                        <i className="fas fa-mobile text-primary" />
                      </div>
                    </Col>
                    <Col md="8" xs="7">
                      <div className="numbers">
                        <p className="card-category">Simcards</p>
                        {this.state.isLoading ? (
                          <Spinner color="primary" />
                        ) : (
                          <CardTitle tag="p">
                            {this.state.simcards.length}
                          </CardTitle>
                        )}
                      </div>
                    </Col>
                  </Row>
                </CardBody>
                <CardFooter>
                  <hr />
                  {this.state.isLoading ? (
                    <></>
                  ) : (
                    <div className="stats">
                      <span className="pull-left">
                        <MyModal
                          title="Simcard Form"
                          buttonLabel="Add"
                          color="success"
                          icon="fas fa-plus"
                          content={
                            <SimcardForm
                              simcardId="new"
                              branches={this.state.branches}
                              employees={this.state.employees}
                              toggle={this.simcardFormToggle}
                            />
                          }
                          modal={this.state.simcardFormModal}
                          toggle={this.simcardFormToggle}
                        />
                      </span>
                      <span className="pull-right">
                        <MyModal
                          toggle={this.simcardTableToggle}
                          modal={this.state.simcardTableModal}
                          title="Simcards"
                          buttonLabel="View"
                          color="warning"
                          icon="fas fa-pen"
                          content={
                            <SimcardsTable
                              simcards={this.state.simcards}
                              branches={this.state.branches}
                              employees={this.state.employees}

                              sortColumn={sortColumn}
                              onDelete={this.handleSimcardDelete}
                              onSort={this.handleSort}
                            />
                          }
                        />
                      </span>
                    </div>
                  )}
                </CardFooter>
              </Card>
            </Col>
          </Row>
          {/* <Row>
            <Col md="12">
              <Card>
                <CardHeader>
                  <CardTitle tag="h5">Branch Performance</CardTitle>
                  <p className="card-category">30 Days performance</p>
                </CardHeader>
                <CardBody>
                  <Line
                    data={dashboard24HoursPerformanceChart.data}
                    options={dashboard24HoursPerformanceChart.options}
                    width={400}
                    height={100}
                  />
                </CardBody>
                <CardFooter>
                  <hr />
                  <div className="stats">
                    <i className="fa fa-history" /> Updated 3 minutes ago
                  </div>
                </CardFooter>
              </Card>
            </Col>
          </Row>
          <Row>
            <Col md="4">
              <Card>
                <CardHeader>
                  <CardTitle tag="h5">Email Statistics</CardTitle>
                  <p className="card-category">Last Campaign Performance</p>
                </CardHeader>
                <CardBody>
                  <Pie
                    data={dashboardEmailStatisticsChart.data}
                    options={dashboardEmailStatisticsChart.options}
                  />
                </CardBody>
                <CardFooter>
                  <div className="legend">
                    <i className="fa fa-circle text-primary" /> Opened{" "}
                    <i className="fa fa-circle text-warning" /> Read{" "}
                    <i className="fa fa-circle text-danger" /> Deleted{" "}
                    <i className="fa fa-circle text-gray" /> Unopened
                  </div>
                  <hr />
                  <div className="stats">
                    <i className="fa fa-calendar" /> Number of emails sent
                  </div>
                </CardFooter>
              </Card>
            </Col>
            <Col md="8">
              <Card className="card-chart">
                <CardHeader>
                  <CardTitle tag="h5">NASDAQ: AAPL</CardTitle>
                  <p className="card-category">Line Chart with Points</p>
                </CardHeader>
                <CardBody>
                  <Line
                    data={dashboardNASDAQChart.data}
                    options={dashboardNASDAQChart.options}
                    width={400}
                    height={100}
                  />
                </CardBody>
                <CardFooter>
                  <div className="chart-legend">
                    <i className="fa fa-circle text-info" /> Tesla Model S{" "}
                    <i className="fa fa-circle text-warning" /> BMW 5 Series
                  </div>
                  <hr />
                  <div className="card-stats">
                    <i className="fa fa-check" /> Data information certified
                  </div>
                </CardFooter>
              </Card>
            </Col>
          </Row> */}
        </div>
      </>
    );
  }
}

export default Dashboard;
