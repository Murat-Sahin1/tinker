import { useState } from "react";
import {
  Box,
  Button,
  TextField,
  useMediaQuery,
  Typography,
  useTheme,
} from "@mui/material";
import EditOutlinedIcon from "@mui/icons-material/EditOutlined";
import { Formik } from "formik";
import * as yup from "yup";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";

import Dropzone from "react-dropzone";
import FlexBetween from "components/FlexBetween";

import axios from "axios";

const modelSchema = yup.object().shape({
  model: yup.string().required("Required"),
});

const initialValues = {
  model: "",
};

const Form = () => {
  const { palette } = useTheme();
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const isNonMobile = useMediaQuery("(min-width:600px)");
  const [file, setFile] = useState();

  const sendModelFile = async (values, onSubmitProps) => {
    console.log(values);
    const formData = new FormData();
    formData.append("files", values.model);
    console.log(formData.get("files"));
    try{
        const res = await axios.post("http://localhost:5074/api/File/Upload", formData);
        console.log(res);
    } catch(ex){
        console.log(ex);
    }
  };

  const handleFormSubmit = async (values, onSubmitProps) => {
    await sendModelFile(values, onSubmitProps);
  };

  return (
    <Formik
      onSubmit={handleFormSubmit}
      initialValues={initialValues}
      validationSchema={modelSchema}
    >
      {({
        values,
        errors,
        touched,
        handleBlur,
        handleChange,
        handleSubmit,
        setFieldValue,
        resetForm,
      }) => (
        <form onSubmit={handleSubmit}>
          <Box
            mt="2rem"
            marginb="2rem"
            display="grid"
            gap="30px" // between items
            gridTemplateColumns="repeat(4, minmax(0, 1fr))"
            sx={{
              "& > div": { gridColumn: isNonMobile ? undefined : "span 4" },
            }}
          >
            <>
              <Box
                gridColumn="span 4"
                border={`1px solid ${palette.neutral.medium}`}
                borderRadius="5px"
                padding="1rem"
              >
                <Dropzone
                  acceptedFiles=".py,.ipynb"
                  multiple={false}
                  onDrop={(acceptedFiles) => {
                    setFieldValue("model", acceptedFiles[0]);
                    setFile(acceptedFiles[0]);
                  }}
                >
                  {({ getRootProps, getInputProps }) => (
                    <Box
                      {...getRootProps()}
                      border={`2px dashed ${palette.primary.main}`}
                      p="1rem"
                      sx={{ "&:hover": { cursor: "pointer" } }}
                    >
                      <input {...getInputProps()} />
                      {!values.model ? (
                        <p>Add File Here</p>
                      ) : (
                        <FlexBetween>
                          <Typography>{values.model.name}</Typography>
                          <EditOutlinedIcon />
                        </FlexBetween>
                      )}
                    </Box>
                  )}
                </Dropzone>
              </Box>
            </>
          </Box>

          {/* BUTTONS */}
          <Box mb="15px">
            <Button
              type="submit"
              display="flex"
              sx={{
                m: "2rem 0",
                p: "1rem",
                width: "65%",
                backgroundColor: palette.primary.main,
                color: palette.background.alt,
                "&:hover": { color: palette.primary.main },
              }}
            >
              LOAD THE MODEL
            </Button>
            <Typography
              sx={{
                textDecoration: "underline",
                color: palette.primary.main,
                "&:hover": { cursor: "pointer", color: palette.primary.light },
              }}
            >
              Click here to get assistance.
            </Typography>
          </Box>
        </form>
      )}
    </Formik>
  );
};

export default Form;
