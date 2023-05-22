import NavBar from "scenes/navbar";
import { useState, useEffect } from "react";
import { Box, Typography, useTheme } from "@mui/material";
import CategoryListingButton from "widgets/categoryWidgets/CategoryListingButton";
import ProductListingWidget from "widgets/categoryWidgets/ProductListingWidget";
import FlexBetween from "components/FlexBetween";
import axios from "axios";
import ThumbUpIcon from "@mui/icons-material/ThumbUp";
import IconCard from "widgets/productDetailWidgets/IconCard";

const ProductDetailPage = () => {
  const theme = useTheme();
  const neutralMain = theme.palette.neutral.mediumMain;
  const neutral = theme.palette.neutral.light;
  const neutralDark = theme.palette.neutral.dark;
  const dark = theme.palette.neutral.dark;
  const background = theme.palette.background.default;
  const primaryLight = theme.palette.primary.light;
  const primaryMain = theme.palette.primary.main;
  const alt = theme.palette.background.alt;
  return (
    <Box>
      <NavBar />
      {/* Container */}
      <Box width="100%" paddingY="1px" justifyContent={"center"} display="flex">
        {/* Alt Color */}
        <Box
          width="100%"
          alignItems={"center"}
          display="flex"
          backgroundColor={alt}
        >
          {/* Header Part */}
          <Box
            marginLeft={"13%"}
            p="1rem"
            display="flex"
            flexDirection={"column"}
            justifyContent={"flex-start"}
          >
            {/* Model Name */}
            <Box
              gap="1rem"
              alignSelf="flex-start"
              padding="1rem"
              marginBottom={"0.3rem"}
              display="flex"
              justifyContent={"center"}
              alignItems={"center"}
            >
              <img
                style={{ objectFit: "cover" }}
                width={"60px"}
                height={"60px"}
                alt="user"
                src="https://images.emojiterra.com/twitter/v13.1/512px/1f916.png"
              />
              <Typography fontSize={"2rem"} fontWeight={"bold"} color="">
                gpt3
              </Typography>
              <Box
                display="flex"
                textAlign={"center"}
                alignItems={"center"}
                justifyContent={"center"}
              >
                <ThumbUpIcon />
                <Typography paddingLeft={"5px"}>234</Typography>
              </Box>
            </Box>
            {/* Icons */}
            <Box display="flex" gap="1rem">
              <IconCard text="Image Transformer" />
              <IconCard text="Image Transformer" />
              <IconCard text="Image Transformer" />
              <IconCard text="Image Transformer" />
              <IconCard text="Image Transformer" />
            </Box>
          </Box>
        </Box>
      </Box>
      <Box paddingTop="1rem" paddingLeft="6rem" width="60%">
        <Box paddingX="2rem" display="flex">
          <Box
            marginLeft={"13%"}
            width="10rem"
            height="4rem"
            sx={{
              "&:hover": {
                backgroundColor: neutralDark,
                cursor: "pointer",
                transitionDuration: "0.4s",
                "& .text": {
                  color: background,
                  transitionDuration: "0.4s",
                },
              },
              borderRadius: "10px 10px 0 0",
              borderRight: `2px ${alt} solid`,
              borderTop: `2px ${alt} solid`,
              borderLeft: `2px ${alt} solid`,
              boxShadow: 3,
              borderBottomColor: {background}
            }}
            justifyContent={"center"}
            alignItems={"center"}
            display="flex"
          >
            <Typography className="text" fontSize="1.2rem">Information</Typography>
          </Box>
          <Box
            marginLeft={"13%"}
            width="10rem"
            height="4rem"
            sx={{
              "&:hover": {
                backgroundColor: neutralDark,
                cursor: "pointer",
                transitionDuration: "0.4s",
                "& .text": {
                  color: background,
                  transitionDuration: "0.4s",
                },
              },
              borderRadius: "10px 10px 0 0",
              borderRight: `2px ${alt} solid`,
              borderTop: `2px ${alt} solid`,
              borderLeft: `2px ${alt} solid`,
              boxShadow: 3,
              borderBottomColor: {background}
            }}
            justifyContent={"center"}
            alignItems={"center"}
            display="flex"
          >
            <Typography className="text" fontSize="1.2rem">Performance</Typography>
          </Box>
          <Box
            marginLeft={"13%"}
            width="10rem"
            height="4rem"
            sx={{
              "&:hover": {
                backgroundColor: neutralDark,
                cursor: "pointer",
                transitionDuration: "0.4s",
                "& .text": {
                  color: background,
                  transitionDuration: "0.4s",
                },
              },
              borderRadius: "10px 10px 0 0",
              borderRight: `2px ${alt} solid`,
              borderTop: `2px ${alt} solid`,
              borderLeft: `2px ${alt} solid`,
              boxShadow: 3,
              borderBottomColor: {background}
            }}
            justifyContent={"center"}
            alignItems={"center"}
            display="flex"
          >
            <Typography className="text" fontSize="1.2rem">Information</Typography>
          </Box>
          <Box
            marginLeft={"13%"}
            width="10rem"
            height="4rem"
            sx={{
              "&:hover": {
                backgroundColor: neutralDark,
                cursor: "pointer",
                transitionDuration: "0.4s",
                "& .text": {
                  color: background,
                  transitionDuration: "0.4s",
                },
              },
              borderRadius: "10px 10px 0 0",
              borderRight: `2px ${alt} solid`,
              borderTop: `2px ${alt} solid`,
              borderLeft: `2px ${alt} solid`,
              boxShadow: 3,
              borderBottomColor: {background}
            }}
            justifyContent={"center"}
            alignItems={"center"}
            display="flex"
          >
            <Typography className="text" fontSize="1.2rem">Information</Typography>
          </Box>
        </Box>
      </Box>
    </Box>
  );
};

export default ProductDetailPage;
