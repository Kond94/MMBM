import React, { Component } from "react";
import { Row } from "reactstrap";
import MyModal from "./../components/common/modal.jsx";
import SimcardForm from "./../components/simcardForm";

class SimcardDetails extends Component {
  state = {};
  state = {
    simcardFormModal: false,
    branches: [],
    employees: []
  };

  simcardFormToggle = async () => {
    this.setState({ simcardFormModal: !this.state.simcardFormModal });
  };
  render() {
    const { simcard } = this.props.location.state;
    return (
      <div className="content">
        <Row>
          <h2>{simcard.phoneNumber}</h2>
          <MyModal
            title="Simcard Form"
            buttonLabel="Edit"
            color="warning"
            icon="fas fa-plus"
            content={
              <SimcardForm
                simcardId={simcard.id}
                branches={this.state.branches}
                employees={this.state.employees}
                toggle={this.simcardFormToggle}
              />
            }
            modal={this.state.simcardFormModal}
            toggle={this.simcardFormToggle}
          />
        </Row>
      </div>
    );
  }
}

export default SimcardDetails;
