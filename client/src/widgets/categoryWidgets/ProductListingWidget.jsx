import { styled } from "@mui/material/styles";
import { Box, Button } from "@mui/material";
import FlexBetween from "components/FlexBetween";
import Typography from "@mui/material/Typography";
import { useTheme } from "@emotion/react";
import LandscapeIcon from "@mui/icons-material/Landscape";
import UserImage from "components/UserImage";

const StyledBox = styled(Box)({
  border: `1px solid #291e11`,
  padding: "0.1rem",
  width: "25rem",
  height: "10rem",
  borderRadius: 9,
  display: "flex",
});

function ProductListingWidget({ onClick, name, description, price }) {
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
    <StyledBox
      onClick={onClick}
      sx={{
        borderWidth: "1px",
        backgroundColor: { alt },
        boxShadow: 7,
        borderColor: neutral,
        "&:hover": {
          backgroundColor: alt,
          cursor: "pointer",
          transitionDuration: "0.4s",
          "& .icon": {
            color: background,
            transitionDuration: "0.4s",
          },
        },
        "&:not(:hover)": {
          backgroundColor: background,
          transitionDuration: "0.4s",
        },
      }}
    >
      <Box
        width="100%"
        display="flex"
        justifyContent={"flex-start"}
        alignItems={"center"}
      >
        <Box
          width={"110px"}
          height={"110px"}
          marginLeft={"1.5rem"}
          justifyContent={"center"}
          alignItems={"center"}
          display="flex"
          sx={{
            border: `2px ${alt} outset`,
            borderWidth: "2px",
            borderColor: { alt },
          }}
        >
          <img
            style={{ objectFit: "cover" }}
            width={"100px"}
            height={"100px"}
            alt="user"
            src="https://images.emojiterra.com/twitter/v13.1/512px/1f916.png"
          />
        </Box>
        <Box
          textAlign={"center"}
          width="100%"
          display="flex"
          flexDirection={"column"}
          alignItems="center"
          justifyContent={"center"}
          gap="0.3rem"
          height="100%"
          position="relative"
        >
          <Box>
            <Typography
              justifyContent="center"
              alignItems={"center"}
              color="primary"
              fontWeight="bold"
              variant="h4"
              textAlign={"center"}
            >
              {name}
            </Typography>
          </Box>
          <Box marginBottom = "25px" paddingX = "0.5rem">
            <Typography fontSize="0.9rem">{description}</Typography>
          </Box>
          <Box position="absolute" bottom="15px">
            <Button variant="contained">
                <Typography fontWeight={"bold"}>
                    Buy
                </Typography>
            </Button>
          </Box>
        </Box>
      </Box>
    </StyledBox>
  );
}

export default ProductListingWidget;
